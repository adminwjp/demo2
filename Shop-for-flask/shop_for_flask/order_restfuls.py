"""
Routes and restfuls for the flask application.
"""

from datetime import datetime
#from shop_for_flask import app, db, model
from shop_for_flask.database import Base,  engine
from shop_for_flask import app, order_model
from utility.util import  j as _json, ma
import json
import sys


from flask import request

from shop_for_flask.session import Session #,  session

import shop_for_flask.base_restfuls as  base
