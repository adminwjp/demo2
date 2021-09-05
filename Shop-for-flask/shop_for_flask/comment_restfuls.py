from shop_for_flask import app, model
from shop_for_flask.database import Base,  engine
from shop_for_flask.session import Session #,  session

import shop_for_flask.base_restfuls as  base

# 注意 flask 添加东西 后 需要重新启动 麻烦 不像 django 一样 自动 运行
#请求  python 太灵活 了 怎么 控制  手动控制
@app.route('/check',methods={"POST", "GET"})
def check():
    return "check"

@app.route('/api/v1/comment/list/<int:page>/<int:size>/<int:comment_sort_by>/<int:comment_object_id>',methods={"POST", "GET"})
def comment_list(page, size,comment_sort_by,comment_object_id):
    return comment_list_by(page,size,comment_sort_by,comment_object_id,0,-1,0)

@app.route('/api/v1/comment/list/<int:page>/<int:size>/<int:comment_sort_by>/<int:comment_object_id>/<int:user_id>/<int:is_private>/<int:parent_id>',methods={"POST", "GET"})
def comment_list_by(page, size,comment_sort_by,comment_object_id,user_id,is_private,parent_id):
    """Renders a comment_list restful."""
    # queryStrings=request.args # ImmutableMultiDict([])
    if page<1 and page>999:
        page=1
    if size<1 and size>99:
        size=10
    query= model.QueryCommentInput()
    query.page=page
    if comment_sort_by==0:
        query.comment_sort_by= model.SortBy_Commentcomment_date
    else :
        query.comment_sort_by=model.SortBy_Commentcomment_date_wrapper_descriptor
    query.comment_object_id=parent_id
    query.user_id=user_id
    query.is_private=is_private
    query.parent_id=parent_id
    return comment_list_by_where(query)

@app.route('/api/v1/comment/list',methods={"POST"})
def comment_list_query_by_where():
    """Renders a comment_list restful."""
    # queryStrings=request.args # ImmutableMultiDict([])
    query= model.QueryCommentInput()
    _json.dic2class(request.json,query)
    if query.page<1 and query.page>999:
        query.page=1
    query.size=10 if query.size<1 and query.size>99 else query.size
    
    return comment_list_by_where(query)

def comment_list_by_where(query):
    session = Session()
    def get_list(p,s):
        data=session.query(model.Comment)
        count=session.query(func.count(model.Comment.id))
        if query.comment_sort_by==model.SortBy_Comment["comment_date"] :
             data=data.order_by(model.Comment.comment_date.asc())
             count=count.order_by(model.Comment.comment_date.asc())
        else :
             data=data.order_by(model.Comment.comment_date.desc())
             count=count.order_by(model.Comment.comment_date.desc())
        if query.comment_object_id>0:
            data=data.filter_by(comment_object_id=query.comment_object_id)
            count=count.filter_by(comment_object_id=query.comment_object_id)
        if query.user_id>0:
            data=data.filter_by(user_id=query.user_id)
            count=count.filter_by(user_id=query.user_id)
        if query.is_private==0:
            data=data.filter_by(is_private=False)
            count=count.filter_by(is_private=False)
        elif query.is_private==1:
            data=data.filter_by(is_private=True)
            count=count.filter_by(is_private=True)
        if query.is_anonymous==0:
            data=data.filter_by(is_anonymous=False)
            count=count.filter_by(is_anonymous=False)
        elif query.is_anonymous==1:
            data=data.filter_by(is_anonymous=True)
            count=count.filter_by(is_anonymous=True)
        #if query.parent_id>0:
        #    data=data.filter_by(parent_id=query.parent_id)
        #    count=count.filter_by(parent_id=query.parent_id)
        if query.audit_status!=model.AuditStatus("none"):
            data=data.filter_by(audit_status=query.audit_status)
            count=count.filter_by(audit_status=query.audit_status)
        if query.owner_id>0:
            data=data.filter_by(owner_id=query.owner_id)
            count=count.filter_by(owner_id=query.owner_id)
        if query.parent_id!="":
            data=data.filter_by(parent_id=query.parent_id)
            count=count.filter_by(parent_id=query.parent_id)
        elif query.parent_ids!="":
            data=data.filter_by(model.Comment.parent_id.in_(query.parent_ids))
            count=count.filter_by(model.Comment.parent_id.in_(query.parent_ids))
        if query.start_comment_date>0:
            data=data.filter_by(comment_date>=query.start_comment_date)
            count=count.filter_by(comment_date>=query.start_comment_date)
        if query.end_comment_date>0:
            data=data.filter_by(comment_date<=query.end_comment_date)
            count=count.filter_by(comment_date<=query.end_comment_date)
        
        count=count.scalar()
        # data=data..limit(size).offset((page-1)*size).all()
        data=data.slice((p - 1) * s, p * s).all()
        arr=[]
        for x in data:
            it=model.Comment.from_json(x)
            arr.append(it)
        return {"data":arr,"result":{"total":count}}
    page=query.page
    size=query.size
    return get_list(page,size)


@app.route('/api/v1/comment/insert',methods={"POST"})
def insert_comment():
    """Renders a insert_comment restful."""
    data=model.Comment()
    _json.dic2class(request.json,data)
    return base.insert(request,data)

# https://blog.csdn.net/qq_32617703/article/details/103579009

@app.route('/api/v1/comment/status/<int:id>/<int:status>',methods={"POST"})
def update_comment_audit_status(id,status):
    """Renders a insert_comment restful."""
    if id<1:
        res={"success":False,"note":"fail","code":301}
        return res
    session = Session()
    res = session.execute('update t_comment set audit_status=%s where id=%s ',status,id)
    session.commit()
    engine.dispose()  #关闭连接
    res={"success":True,"note":"success","code":200}
    return res

@app.route('/api/v1/review/insert',methods={"POST"})
def insert_review():
    """Renders a insert_review restful."""
    data=model.Review()
    return base.insert(request,data)

@app.route('/api/v1/review/list/<int:page>/<int:size>',methods={"POST"})
def list_review(page,size):
    """Renders a list_review restful."""
    review=model.Review()
    _json.dic2class(request.json,review)
    session = Session()
    data=session.query(model.Review)
    count=session.query(func.count(model.Review.id))
    if query.reviewed_object_id>0:
            data=data.filter_by(reviewed_object_id=query.reviewed_object_id)
            count=count.filter_by(reviewed_object_id=query.reviewed_object_id)
    if query.user_id>0:
        data=data.filter_by(user_id=query.user_id)
        count=count.filter_by(user_id=query.user_id)
    if query.is_private==0:
        data=data.filter_by(is_private=False)
        count=count.filter_by(is_private=False)
    elif query.is_private==1:
        data=data.filter_by(is_private=True)
        count=count.filter_by(is_private=True)
    if query.parent_id>0:
        data=data.filter_by(parent_id=query.parent_id)
        count=count.filter_by(parent_id=query.parent_id)
    if query.owner_id>0:
        data=data.filter_by(owner_id=query.owner_id)
        count=count.filter_by(owner_id=query.owner_id)
   
    count=count.scalar()
    if page<1 and page>999:
        page=1
    size=10 if size<1 and size>99 else size
    
    data=data.limit(size).offset((page-1)*size).all()
    res={"success":True,"note":"success","code":200}
    return res

@app.route('/api/v1/review_summary/save',methods={"POST"})
def save_review_summary():
    """Renders a insert_review_summary restful."""
    review=model.ReviewSummary()
    _json.dic2class(request.json,review)
    session = Session()
    if review.id>0:
        temp=session.query(model.ReviewSummary).filter_by(id=review.id).one()
        if temp==None:
            res={"success":False,"note":"fail","code":301}
            return res
        temp.owner_id=review.owner_id
        temp.reviewed_object_id=review.reviewed_object_id
        temp.positive_reivew_count=review.positive_reivew_count
        temp.moderate_reivew_count=review.moderate_reivew_count
        temp.negative_reivew_count=review.negative_reivew_count
        temp.rate_sum=review.rate_sum
        temp.rate_count=review.rate_count
    else :
        session.add(review)
    session.commit()
    engine.dispose()  #关闭连接
    res={"success":True,"note":"success","code":200}
    return res



@app.route('/api/v1/review_summary/list/<int:page>/<int:size>',methods={"POST"})
def list_review_summary(page,size):
    """Renders a list_review restful."""
    review=model.Review()
    _json.dic2class(request.json,review)
    session = Session()
    data=session.query(model.Review)
    count=session.query(func.count(model.Review.id))
    if query.reviewed_object_id>0:
            data=data.filter_by(reviewed_object_id=query.reviewed_object_id)
            count=count.filter_by(reviewed_object_id=query.reviewed_object_id)
    if query.rate_sum>0:
        data=data.filter_by(rate_sum=query.rate_sum)
        count=count.filter_by(rate_sum=query.rate_sum)
    
    if query.rate_count>0:
        data=data.filter_by(rate_count=query.rate_count)
        count=count.filter_by(rate_count=query.rate_count)
    if query.owner_id>0:
        data=data.filter_by(owner_id=query.owner_id)
        count=count.filter_by(owner_id=query.owner_id)
   
    count=count.scalar()
    if page<1 and page>999:
        page=1
    size=10 if size<1 and size>99 else size
    
    data=data.limit(size).offset((page-1)*size).all()
    res={"success":True,"note":"success","code":200}
    return res

@app.route('/api/v1/review_summary/sum/<int:owner_id>',methods={"GET"})
def rate_sum_review_summary(owner_id):
    """Renders a list_review restful."""
    sql="select IsNull(sum(rate_sum),0) from t_review_summary where owner_id =%s"
    return ""

@app.route('/api/v1/review_summary/count/<int:owner_id>',methods={"GET"})
def rate_count_review_summary(owner_id):
    """Renders a list_review restful."""
    sql="select IsNull(sum(rate_count),0) from t_review_summary where owner_id =%s"
    return ""
    