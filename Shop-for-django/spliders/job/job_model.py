# 使用枚举
from enum import Enum

# recruit flag 招聘枚举
# 枚举参考
# https://www.cnblogs.com/enjoyourself/archive/2010/06/15/1758618.html
# https://www.cnblogs.com/huwt/p/11183768.html
class RecruitFlag(Enum):
    
    zhaoping=0  # 智联招聘
    five_one_job=1   # 51job招聘
    lagou=2  # 拉钩招聘


# recruit model 招聘模型 RecruitFlag 必须放在上面 放在下面编译不过 类属性不声明 account  编译不过 account:"" or account="" 编译 pass 
class Recruit:
    email :"" # 邮箱
    phone:""   # 手机号
    pwd :""  # 密码
    flag:RecruitFlag.zhaoping # 智联招聘



# login model 登录结果
class Login:
    success:0  # 登录状态 默认失败 true false不支持的语法

# recruit job 招聘职位
class RecruitJob:
    id :""  # 招聘id
    name :"" # 招聘职位名称
    publish_date :"" # 招聘职位发布时间
    company :0.0  # 招聘公司
    salary :"" # 职位薪资
    link :""  # 招聘链接
    company_link:""  # 招聘公司链接