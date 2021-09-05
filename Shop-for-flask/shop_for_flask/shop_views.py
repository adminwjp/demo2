from datetime import datetime
from flask import render_template
from shop_for_flask import app
#import common
@app.route('/favicon.ico')
def favicon():
    return app.send_static_file('favicon.ico')

@app.route("/admin/home")
def admin_home():
    """Renders the home page."""
    return render_template(
        "admin/index.html",
        #sourcre_api=common.sourcre_api
    )

# easyui 
@app.route("/admin/carousel")
def admin_carousel():
    return render_template(
        "admin/carousel.html",
        #sourcre_api=common.sourcre_api
    )

# hui-admin
@app.route("/admin/category")
def admin_category():
    return render_template(
        "admin/category.html",
        #sourcre_api=common.sourcre_api
    )

# angular
@app.route("/admin/address")
def admin_address():
    return render_template(
        "admin/address.html",
        #sourcre_api=common.sourcre_api
    )

# ace  jqgrid
@app.route("/admin/cart")
def admin_cart():
    return render_template(
        "admin/cart.html",
        #sourcre_api=common.sourcre_api
    )

# react
@app.route("/admin/user")
def admin_user():
    return render_template(
        "admin/user.html",
        #sourcre_api=common.sourcre_api
    )

# element-ui
@app.route("/admin/product")
def admin_product():
    return render_template(
        "admin/product.html",
        #sourcre_api=common.sourcre_api
    )

# element-ui
@app.route("/admin/menu")
def admin_menu():
    return render_template(
        "admin/menu.html",
        #sourcre_api=common.sourcre_api
    )
