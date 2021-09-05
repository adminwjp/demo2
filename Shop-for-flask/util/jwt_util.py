import python_jwt as jwt, jwcrypto.jwk as jwk, datetime
key = jwk.JWK.generate(kty='RSA', size=2048)
priv_pem = key.export_to_pem(private_key=True, password=None)
pub_pem = key.export_to_pem()
print(priv_pem)
print(pub_pem)
payload = { 'foo': 'bar', 'wup': 90 };
priv_key = jwk.JWK.from_pem(priv_pem)
pub_key = jwk.JWK.from_pem(pub_pem)
token = jwt.generate_jwt(payload, priv_key, 'RS256', datetime.timedelta(minutes=5))
print(token)

header, claims = jwt.verify_jwt(token, pub_key, ['RS256'])
for k in payload: 
    if claims[k] == payload[k]:
        print(claims[k])


# OctetJWK RSAJWK

"""
import time
import jwt
import jwt.jwk as jwk
# https://www.cnblogs.com/lowmanisbusy/p/10930856.html

payload = {
    'iat': time.time(),  
    'name':'test'
}


headers = {
    'alg': "HS256",
}
jwt_instance=jwt.JWT()

jwt_token = jwt_instance.encode(payload,  
    jwk.OctetJWK(b"zhananbudanchou1234678"),  
    alg="HS256", 
    optional_headers=headers 
    ) #.decode('ascii') 

print(jwt_token)

jwt_token1 = jwt_instance.decode(jwt_token,  
    jwk.OctetJWK(b"zhananbudanchou1234678"),  
    algorithms="HS256", 
    )

print(jwt_token1)

# ras jwt error
'''
import rsa
from typing import Union
(pubkey, privkey) = rsa.newkeys(1024)
pub = pubkey.save_pkcs1()
print(pub)
pri = privkey.save_pkcs1()
print(pri)
'''
from cryptography.hazmat.backends import _get_backend 
from cryptography.hazmat.backends.openssl  import rsa
#jwt.jwk.RSAPublicKey
#rsa._RSAPrivateKey
keyobj=privkey
jwt_token = jwt_instance.encode(payload,  
    jwk.RSAJWK(keyobj=privkey),  
    alg="RS256", 
    optional_headers=headers 
    ) #.decode('ascii') 
print(jwt_token)

jwt_token1 = jwt_instance.decode(jwt_token,  
    jwk.RSAJWK(keyobj=pubkey),  
    algorithms="RS256", 
    )
print(jwt_token1)

"""

      
      


