from django.http import HttpRequest, HttpResponse, HttpResponseNotFound
from django.utils.deprecation import MiddlewareMixin
import json
# 定义中间件类，处理全局异常
# https://www.cnblogs.com/sch01ar/p/11508002.html
class ExceptionGlobalMiddleware(MiddlewareMixin):
    
    # 如果注册多个process_exception函数，那么函数的执行顺序与注册的顺序相反。(其他中间件函数与注册顺序一致)
    # 中间件函数，用到哪个就写哪个，不需要写所有的中间件函数。
    def process_exception(self, request, exception):
        """视图函数发生异常时调用"""
        print("----process_exception1----")
        print(exception)
        body = dict(
            msg="InternalServerError",
            code=500,
            success=False,
            node="error" #,
            #request=request.method 
        )
        text = json.dumps(body)
        return HttpResponse(text)

