
# https://blog.csdn.net/weixin_34075551/article/details/92039633

class InvalidUsage(Exception):
    code = 400
 
    def __init__(self, message, code=None, payload=None):
        Exception.__init__(self)
        self.message = message
        if code is not None:
            self.code = code
        self.payload = payload
 
    def to_dict(self):
        rv = dict(self.payload or ())
        rv["message"] = self.message
        return rv


from flask import Blueprint, jsonify
 
cbp = Blueprint("ex", __name__)

@cbp.app_errorhandler(InvalidUsage)
def handle_invalid_usage(error):
    response = jsonify(error.to_dict())
    response.code = error.code
    return response
