
import configparser
import os

class ReadConfig:
    """定义一个读取配置文件的类"""

    def __init__(self, filepath=None):
        if filepath:
            configpath = filepath
        else:
            root_dir = os.path.dirname(os.path.abspath('.'))
            configpath = os.path.join(root_dir, "config/config.ini")
        self.cf = configparser.ConfigParser()
        self.cf.read(configpath)

    def get_db(self,section, param):
        value = self.cf.get(section, param)
        return value

cfg=None

def load_cfg():
    if cfg==None:
      cfg=ReadConfig()


