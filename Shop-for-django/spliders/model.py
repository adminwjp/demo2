from enum import Enum 
import time

class Account:
   username = "" # 账号
   password = "" # 密码
   key = "" # key
   mac = "" # 本机mac
   phone = "" # 账号绑定手机号码


class PhoneState(Enum):
    """ 日志字段枚举 插件只需处理State_Know，State_Unknow """
    state_suc = 101  # 扣费检查正常（拨打成功）
    state_know = 102 # 号码状态正常（非空号）
    state_fail = 103 # 扣费检查异常（关机可疑）
    state_minus = 104 # 余额为负（停机可以）
    state_conflict = 300 # 状态冲突（需人工判断）
    state_unknow = 400 # 号码状态未知（无法判断）
    state_exc = 501 # 拨打异常（打不通但非空号，包含停机、关机）
    tate_doubt = 502 # 拨打可疑（打不通，包含空号、停机、关机等）
    state_close = 503 # 关机
    state_stop = 504 # 停机
    vacant_number = 505 # 空号

class Log:
   cp =""  # 手机号 
   key = ""  # 单次查询标记位
   uts =long(time.time()) #本次查询时间戳
   content =""  # 日志内容

class Data: 
    cp = ""  # 手机号
    prov = ""  # 省份
    city =""  # 城市
    op = ""  # 运营商类型
    uts = long(time.time()) #本次查询时间戳
    company =""  # 付费公司
    name = ""  # 姓名
    balance =""  # 当前余额
    meal =""  # 套餐
    charge_money = 0  # 充值金额
    state = PhoneState.State_Unknow # 用户状态 1扣费检查正常 0扣费检查异常 2号码状态正常 3空号 4号码状态未知
    payment_type =""  # 付费类型
    remark = ""  # 备注
    ident = ""  # 当前操作者
    session_id = ""  # 当前的

class Phone:
    mobile_number= ""  # 手机号
    mobile_type = ""  # 运营商类型
    area_code=""
    post_code =""  # 邮编
    mobile_area = ""  # 地区
   

class DataIp:
    ip =""  # 代理ip
    uts = 0 # 时间戳
    condition = True # ip状态

class InheritanceOrder : 
    sate_ip=False
    pf_crawl=""
    countener=0
    website_state=False # 查询状态
    user_flag="" #支付宝状态返回状态
    local="" # 本机IP
    web_list=[] # 缓存第三方网站

class Mongod:
    num = "app_phone_num" #数据列表
    log = "app_phone_log" #日志列表
    state = "app_phone_nuknown" #状态为400表
    test = "app_phone_test" #测试数据表
    personal = "data_person" #个人数据表
    attribution = "dm_mobile" #号码归属地表
    repertory = "new_phones" #原始数据表
    app_phone_bank = "app_phone_bank" #写mysql异常，暂时写入mongo
    newrepertory = "phone_priority_jd" #原始数据表

class MySqlTable:
    person = "person" #个人详情表
    idcard_phone = "idcard_phone" #证件号码对应表
    idcard_phone_his = "idcard_phone_his" #证件号码对应历史查询表
    phone_detail = "phone_detail" #号码关系表
    phone_logs = "phone_logs" #日志表
    internet_tag = "internet_tag" #互联网数据表
    phone_test = "phone_test" #号码关系测试表
    log_test = "log_test" #日志测试表

class PersonState(Enum):
    name_equ = 1001 # 姓名相同
    name_unequ = 1002 # 姓名不同
    name_unknow = 1003 # 未查询到姓名
    name_unnumber = 1004 # 未走查询渠道

class Person:

    name = ""  # 姓名
    gender = ""  # 性别
    idcard = ""  # 身份证号码
    phone = ""  # 手机号码
    telnumber = ""  # 固定电话
    email =""  # 邮箱地址
    address = ""  # 家庭住址
    user_flag = ""  # 查询状态
    uts = long(time.time()) #时间戳
    ortheraddress = ""  # 其他地址


class ThridApp:
    phone =  ""  # 手机号码
    thridapp = ""  # 第三方网站名称
    uts = long(time.time()) #时间戳
    useflag = UseFlag.unknow #绑定状态
    account = ""  # 账号
    name =  ""  # 名称
    image_url =  ""  # 头像地址
    note =  ""  # 备注
    ip=""
    port=0
    use_ip=False
    local_ip=""


class SocialName:
    """ 第三方网站社交状态 """
    thridWebsite =  ""  # 网站名称
    ebsite_state = True  # 上线状态（默认我上线）
    uts = long(time.time()) #时间戳
   

class UseFlag:
    """ 绑定状态 """
    suc = "0000" # 绑定成功
    fail = "0001" # 未绑定
    unknow = "0002" # 绑定状态未知
    times = "0003" # 请求超时绑定状态未知
    changeweb = "0004" # 其他原因绑定状态未知