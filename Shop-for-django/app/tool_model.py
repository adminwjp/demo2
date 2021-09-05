class tool_model(object):
    """description of class"""

from enum import Enum

class ParseFlag(Enum):

    '''
    One
    csharp map -> java map
    ["a"]="b" -> map.add("a","b");
    csharp:
    Dictionary<string,string> errCodeToErrMsg = new Dictionary<string, string>()
        {
            ["-1"] = "系统繁忙，此时请开发者稍候再试",
            ["0"] = "请求成功",
         };
    java
    Map<String,String> errCodeToErrMsg=new Map<String,String>();
    errCodeToErrMsg.put("-1","系统繁忙，此时请开发者稍候再试");


    '''
    One=0
   
import string 

class ToolHelper:
    def parse(self,str,flag):
       if str=="":
           return ""
       # switch
       # 支持无参方法
       # https://www.cnblogs.com/dbf-/p/10601216.html
       #switch={
       #    ParseFlag.One:self._one
       #    }
       #try:
       #    return switch.get(flag,self._default) # err
       #    m= switch.get(flag,self._default)
       #    return m(str) # err
       #except:
       #    return "ex"
       #finally:
       #    pass
       ###

       if flag== ParseFlag.One:
           return self._one(str)
       return ""
    
    def _default(self,str):
         return ""
    def _one(self,str):
        # print(str.length) # err
        # print(count(str))  # err
        # print(len(str)) # err
        #strs=str.split("[\r|\n]",len(str))
        strs=str.split("\n") # pass right
        # strs=str.splitlines("\r\n") # err
        if strs!=None and len(strs)>0:
            temp=""
            print(len(strs))
            # count(strs) string.count(strs) err len(strs) pass
            for i in range(len(strs)):
                kvs=strs[i].split("=")
                k=kvs[0]
                v=kvs[1]
                temp+="errCodes.put("+k.replace("[","").replace("]","").replace(" ","")
                temp+=","+v.replace(",","").replace(" ","")+");\n"

            return temp;
        else:
            return ""

toolHelper=ToolHelper()
s=""
try:
 f=open('context.txt', 'r')
 s=f.read()
 # print(s)
finally:
 if f:
   f.close()

str=toolHelper.parse(s,ParseFlag.One)
print(str)
try:
 f=open('context.log', 'w')
 f.write(str)
 # print(s)
finally:
 if f:
   f.close()


