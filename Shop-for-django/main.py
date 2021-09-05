import spliders.product.jindon  as jindon
jd=jindon.JinDon()
import json

#jd.crawl()
# error
#jd.parse_file(jindon.dir+"\index.html")
shop_catalogs=[]
items=[]
with open(jindon.dir+"\index.html","r", encoding="utf8") as f:
    context=f.read() # pass 
    #context=f.readlines() # error 
    #print(context)
    shop_catalogs=jd.parse(context)

with open(jindon.dir+"\jd_catalog.json","r", encoding="utf8") as f:
    context=f.read() # pass 
    temp=context.replace("getCategoryCallback(","")
    list_str=list(temp)
    # list_str.pop(list_str.count()-1) # error 
    list_str.pop(len(list_str)-1)
    temp="".join(list_str)
    # error 
    #print(temp)
    dic = json.loads(temp)

    items=jd.parse_json(dic["data"])

jd.save_data(shop_catalogs,items)

#save db
from spliders.common import HttpHelper
url="http://127.0.0.1:5999/api/v1/catalog/insert_many"
http_helper=HttpHelper()
result=http_helper.post_json_by_data(url,shop_catalogs,"",http_helper.get_headers())
print(result)
# error write suc
#  read error python UnicodeDecodeError: 'utf-8' codec can't decode
#with open("data\jd.json","rb") as f:
#    str1=json.load(f)
#    print(str1)
  
    