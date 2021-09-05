"""
This script runs the shop_for_flask application using a development server.
"""
# pip install Flask
# flask --help
# set FLASK_APP=hello.py
# set FLASK_ENV=development
# flask run

# flask run --host=0.0.0.0 --port=8000 # not support
# python runserver.py

from os import environ
from shop_for_flask import app
import logging
from flasgger import Swagger
Swagger(app)
# pip install flask-cors 
from flask_cors import CORS

CORS(app, resources=r"/*")
from enum import Enum

class return_code(Enum):
    Unauthorized=400,
    Forbidden=403,
    NotFound=404,
    InternalServerError=500


from werkzeug.exceptions import HTTPException
from flask import request
import json

class APIException(HTTPException):
    code=500
    node=""
    success=False
    msg=""

    def __init__(self,code,msg=None):
        #if code in return_code._value2member_map_:
        #print("code")
        self.code=code.value
        self.node=code.name
        self.msg= msg if msg else code.name
        #else:
        #    print("code fail")
        super(APIException, self).__init__(msg, None)

    def get_body(self, environ=None):
        body = dict(
            msg=self.msg,
            code=self.code,
            success=self.success,
            node=self.node,
            request=request.method + " " + self.get_url_no_param()
        )
        text = json.dumps(body)
        return text
 
    def get_headers(self, environ=None):
        """Get a list of headers."""
    @staticmethod
    def get_url_no_param():
        full_path = str(request.full_path)
        main_path = full_path.split("?")
        return main_path[0]
        
   

def register_errors(app):
    @app.errorhandler(400)
    def bad_request(e):
        return APIException(return_code.Unauthorized)

    @app.errorhandler(403)
    def forbidden(e):
        return APIException(return_code.Forbidden)

    @app.errorhandler(404)
    def database_not_found_error_handler(e):
        return APIException(return_code.NotFound)

    @app.errorhandler(405)
    def method_not_allowed(e):
        return APIException(return_code.Illegalmethod, "The method is not allowed for the requested URL.")

    @app.errorhandler(500)
    def internal_server_error(e):
        return APIException(return_code.InternalServerError, "An internal server error occurred.")

    # The default_error_handler function as written above will not return any response if the Flask application
    # is running in DEBUG mode.
    @app.errorhandler
    def default_error_handler(e):
        message = "An unhandled exception occurred. -> {}".format(str(e))
        logger.error(message)

        # if not settings.FLASK_DEBUG:
        return APIException(return_code.InternalServerError, message)

register_errors(app)
#from util import ex



if __name__ == "__main__":
    HOST = environ.get("SERVER_HOST", "0.0.0.0")
    try:
        PORT = int(environ.get("SERVER_PORT", "8000"))
    except ValueError:
        PORT = 8000
    app.run(HOST, PORT)
