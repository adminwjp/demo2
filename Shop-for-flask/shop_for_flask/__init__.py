"""
The flask application package.
"""

from flask import Flask

app = Flask(__name__)



import shop_for_flask.views
import shop_for_flask.shop_views
import shop_for_flask.restfuls
import shop_for_flask.comment_restfuls
import shop_for_flask.order_restfuls
import shop_for_flask.product_restfuls
import shop_for_flask.upload_restfuls

