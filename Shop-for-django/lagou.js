/*!common/components/util/htoc.js*/
;
define("common/components/util/htoc", ["require", "exports", "module"],
function(require, exports, module) {
    module.exports = {
        HtoC: function(c) {
            for (var a = c.val(), t = "", i = 0; i < a.length; i++) t += String.fromCharCode(a.charCodeAt(i) > 65248 && a.charCodeAt(i) < 65375 ? a.charCodeAt(i) - 65248 : a.charCodeAt(i));
            c.val(t)
        }
    }
});
/*!common/static/js/base-captcha/index.js*/
; !
function(c, a) {
    "object" == typeof exports && "undefined" != typeof module ? a(exports) : "function" == typeof define && define.amd ? define("common/static/js/base-captcha/index", ["exports"], a) : (c = c || self, a(c["base-captcha-main"] = {}))
} (this,
function(exports) {
    "use strict";
    function c(c, module) {
        return module = {
            exports: {}
        },
        c(module, module.exports),
        module.exports
    }
    function a() {
        var c;
        qc(c = window.lagouSenseCallbackList).call(c,
        function(c) {
            c && c()
        }),
        window.lagouSenseCallbackList = []
    }
    function v(c) {
        var a = c.url,
        v = c.method,
        y = c.params,
        g = c.successCallback,
        w = c.errorCallback;
        h(a, v, y, g, w)
    }
    function h(c, a, v, h, y) {
        var g = new XMLHttpRequest;
        g.open(a, c, !0),
        g.onerror = function() {
            y && y()
        },
        g.onreadystatechange = function() {
            if (4 == g.readyState) {
                var c = g.responseText;
                try {
                    c = JSON.parse(c)
                } catch(a) {}
                h && h(c)
            }
        };
        var w;
        if (v) {
            var b = [];
            for (var S in v) b.push(S + "=" + encodeURIComponent(v[S]));
            w = b.join("&"),
            w.length && g.setRequestHeader("Content-type", "application/x-www-form-urlencoded")
        }
        g.send(w)
    }
    function y(c, a) {
        v({
            url: "//passport.lagou.com/jsVersonNumber/getJsVersionNumber.json?keyCode=".concat(a),
            method: "get",
            successCallback: c,
            errorCallback: c
        })
    }
    var g = "undefined" != typeof globalThis ? globalThis: "undefined" != typeof window ? window: "undefined" != typeof global ? global: "undefined" != typeof self ? self: {},
    w = function(c) {
        return c && c.Math == Math && c
    },
    b = w("object" == typeof globalThis && globalThis) || w("object" == typeof window && window) || w("object" == typeof self && self) || w("object" == typeof g && g) || Function("return this")(),
    S = function(c) {
        try {
            return !! c()
        } catch(a) {
            return ! 0
        }
    },
    j = !S(function() {
        return 7 != Object.defineProperty({},
        1, {
            get: function() {
                return 7
            }
        })[1]
    }),
    O = function(c) {
        return "object" == typeof c ? null !== c: "function" == typeof c
    },
    T = b.document,
    L = O(T) && O(T.createElement),
    E = function(c) {
        return L ? T.createElement(c) : {}
    },
    P = !j && !S(function() {
        return 7 != Object.defineProperty(E("div"), "a", {
            get: function() {
                return 7
            }
        }).a
    }),
    C = function(c) {
        if (!O(c)) throw TypeError(String(c) + " is not an object");
        return c
    },
    A = function(c, a) {
        if (!O(c)) return c;
        var v, h;
        if (a && "function" == typeof(v = c.toString) && !O(h = v.call(c))) return h;
        if ("function" == typeof(v = c.valueOf) && !O(h = v.call(c))) return h;
        if (!a && "function" == typeof(v = c.toString) && !O(h = v.call(c))) return h;
        throw TypeError("Can"t convert object to primitive value")
    },
    k = Object.defineProperty,
    f = j ? k: function(c, a, v) {
        if (C(c), a = A(a, !0), C(v), P) try {
            return k(c, a, v)
        } catch(h) {}
        if ("get" in v || "set" in v) throw TypeError("Accessors not supported");
        return "value" in v && (c[a] = v.value),
        c
    },
    M = {
        f: f
    },
    I = function(c, a) {
        return {
            enumerable: !(1 & c),
            configurable: !(2 & c),
            writable: !(4 & c),
            value: a
        }
    },
    _ = j ?
    function(c, a, v) {
        return M.f(c, a, I(1, v))
    }: function(c, a, v) {
        return c[a] = v,
        c
    },
    D = {}.hasOwnProperty,
    F = function(c, a) {
        return D.call(c, a)
    },
    G = function(c, a) {
        try {
            _(b, c, a)
        } catch(v) {
            b[c] = a
        }
        return a
    },
    N = "__core-js_shared__",
    R = b[N] || G(N, {}),
    V = R,
    z = Function.toString;
    "function" != typeof V.inspectSource && (V.inspectSource = function(c) {
        return z.call(c)
    });
    var H, K, W, B = V.inspectSource,
    U = b.WeakMap,
    Y = "function" == typeof U && /native code/.test(B(U)),
    J = c(function(module) { (module.exports = function(c, a) {
            return V[c] || (V[c] = void 0 !== a ? a: {})
        })("versions", []).push({
            version: "3.6.5",
            mode: "global",
            copyright: "© 2020 Denis Pushkarev (zloirock.ru)"
        })
    }),
    X = 0,
    $ = Math.random(),
    Q = function(c) {
        return "Symbol(" + String(void 0 === c ? "": c) + ")_" + (++X + $).toString(36)
    },
    Z = J("keys"),
    tn = function(c) {
        return Z[c] || (Z[c] = Q(c))
    },
    nn = {},
    en = b.WeakMap,
    rn = function(c) {
        return W(c) ? K(c) : H(c, {})
    },
    on = function(c) {
        return function(a) {
            var v;
            if (!O(a) || (v = K(a)).type !== c) throw TypeError("Incompatible receiver, " + c + " required");
            return v
        }
    };
    if (Y) {
        var cn = new en,
        un = cn.get,
        an = cn.has,
        fn = cn.set;
        H = function(c, a) {
            return fn.call(cn, c, a),
            a
        },
        K = function(c) {
            return un.call(cn, c) || {}
        },
        W = function(c) {
            return an.call(cn, c)
        }
    } else {
        var sn = tn("state");
        nn[sn] = !0,
        H = function(c, a) {
            return _(c, sn, a),
            a
        },
        K = function(c) {
            return F(c, sn) ? c[sn] : {}
        },
        W = function(c) {
            return F(c, sn)
        }
    }
    var ln = {
        set: H,
        get: K,
        has: W,
        enforce: rn,
        getterFor: on
    },
    pn = c(function(module) {
        var c = ln.get,
        a = ln.enforce,
        v = String(String).split("String"); (module.exports = function(c, h, y, g) {
            var w = g ? !!g.unsafe: !1,
            S = g ? !!g.enumerable: !1,
            j = g ? !!g.noTargetGet: !1;
            return "function" == typeof y && ("string" != typeof h || F(y, "name") || _(y, "name", h), a(y).source = v.join("string" == typeof h ? h: "")),
            c === b ? void(S ? c[h] = y: G(h, y)) : (w ? !j && c[h] && (S = !0) : delete c[h], void(S ? c[h] = y: _(c, h, y)))
        })(Function.prototype, "toString",
        function() {
            return "function" == typeof this && c(this).source || B(this)
        })
    }),
    vn = Date.prototype,
    dn = "Invalid Date",
    hn = "toString",
    yn = vn[hn],
    gn = vn.getTime;
    new Date(0 / 0) + "" != dn && pn(vn, hn,
    function() {
        var c = gn.call(this);
        return c === c ? yn.call(this) : dn
    });
    var mn = Math.ceil,
    wn = Math.floor,
    bn = function(c) {
        return isNaN(c = +c) ? 0 : (c > 0 ? wn: mn)(c)
    },
    Sn = function(c) {
        if (void 0 == c) throw TypeError("Can"t call method on " + c);
        return c
    },
    jn = function(c) {
        return function(a, v) {
            var h, y, g = String(Sn(a)),
            w = bn(v),
            b = g.length;
            return 0 > w || w >= b ? c ? "": void 0 : (h = g.charCodeAt(w), 55296 > h || h > 56319 || w + 1 === b || (y = g.charCodeAt(w + 1)) < 56320 || y > 57343 ? c ? g.charAt(w) : h: c ? g.slice(w, w + 2) : (h - 55296 << 10) + (y - 56320) + 65536)
        }
    },
    On = {
        codeAt: jn(!1),
        charAt: jn(!0)
    },
    Tn = function(c) {
        return c && c.Math == Math && c
    },
    Ln = Tn("object" == typeof globalThis && globalThis) || Tn("object" == typeof window && window) || Tn("object" == typeof self && self) || Tn("object" == typeof g && g) || Function("return this")(),
    En = function(c) {
        try {
            return !! c()
        } catch(a) {
            return ! 0
        }
    },
    Pn = !En(function() {
        return 7 != Object.defineProperty({},
        1, {
            get: function() {
                return 7
            }
        })[1]
    }),
    Cn = function(c) {
        return "object" == typeof c ? null !== c: "function" == typeof c
    },
    An = Ln.document,
    xn = Cn(An) && Cn(An.createElement),
    kn = function(c) {
        return xn ? An.createElement(c) : {}
    },
    Mn = !Pn && !En(function() {
        return 7 != Object.defineProperty(kn("div"), "a", {
            get: function() {
                return 7
            }
        }).a
    }),
    In = function(c) {
        if (!Cn(c)) throw TypeError(String(c) + " is not an object");
        return c
    },
    _n = function(c, a) {
        if (!Cn(c)) return c;
        var v, h;
        if (a && "function" == typeof(v = c.toString) && !Cn(h = v.call(c))) return h;
        if ("function" == typeof(v = c.valueOf) && !Cn(h = v.call(c))) return h;
        if (!a && "function" == typeof(v = c.toString) && !Cn(h = v.call(c))) return h;
        throw TypeError("Can"t convert object to primitive value")
    },
    Dn = Object.defineProperty,
    Fn = Pn ? Dn: function(c, a, v) {
        if (In(c), a = _n(a, !0), In(v), Mn) try {
            return Dn(c, a, v)
        } catch(h) {}
        if ("get" in v || "set" in v) throw TypeError("Accessors not supported");
        return "value" in v && (c[a] = v.value),
        c
    },
    Gn = {
        f: Fn
    },
    Nn = function(c, a) {
        return {
            enumerable: !(1 & c),
            configurable: !(2 & c),
            writable: !(4 & c),
            value: a
        }
    },
    Rn = Pn ?
    function(c, a, v) {
        return Gn.f(c, a, Nn(1, v))
    }: function(c, a, v) {
        return c[a] = v,
        c
    },
    Vn = function(c, a) {
        try {
            Rn(Ln, c, a)
        } catch(v) {
            Ln[c] = a
        }
        return a
    },
    zn = "__core-js_shared__",
    Hn = Ln[zn] || Vn(zn, {}),
    Kn = Hn,
    Wn = Function.toString;
    "function" != typeof Kn.inspectSource && (Kn.inspectSource = function(c) {
        return Wn.call(c)
    });
    var qn, Bn, Un, Yn = Kn.inspectSource,
    Jn = Ln.WeakMap,
    Xn = "function" == typeof Jn && /native code/.test(Yn(Jn)),
    $n = {}.hasOwnProperty,
    Qn = function(c, a) {
        return $n.call(c, a)
    },
    Zn = !0,
    te = c(function(module) { (module.exports = function(c, a) {
            return Kn[c] || (Kn[c] = void 0 !== a ? a: {})
        })("versions", []).push({
            version: "3.6.4",
            mode: "pure",
            copyright: "© 2020 Denis Pushkarev (zloirock.ru)"
        })
    }),
    ee = 0,
    oe = Math.random(),
    ie = function(c) {
        return "Symbol(" + String(void 0 === c ? "": c) + ")_" + (++ee + oe).toString(36)
    },
    ce = te("keys"),
    ue = function(c) {
        return ce[c] || (ce[c] = ie(c))
    },
    ae = {},
    fe = Ln.WeakMap,
    se = function(c) {
        return Un(c) ? Bn(c) : qn(c, {})
    },
    pe = function(c) {
        return function(a) {
            var v;
            if (!Cn(a) || (v = Bn(a)).type !== c) throw TypeError("Incompatible receiver, " + c + " required");
            return v
        }
    };
    if (Xn) {
        var ve = new fe,
        he = ve.get,
        ye = ve.has,
        ge = ve.set;
        qn = function(c, a) {
            return ge.call(ve, c, a),
            a
        },
        Bn = function(c) {
            return he.call(ve, c) || {}
        },
        Un = function(c) {
            return ye.call(ve, c)
        }
    } else {
        var me = ue("state");
        ae[me] = !0,
        qn = function(c, a) {
            return Rn(c, me, a),
            a
        },
        Bn = function(c) {
            return Qn(c, me) ? c[me] : {}
        },
        Un = function(c) {
            return Qn(c, me)
        }
    }
    var we, be, Se, je = {
        set: qn,
        get: Bn,
        has: Un,
        enforce: se,
        getterFor: pe
    },
    Oe = {}.propertyIsEnumerable,
    Te = Object.getOwnPropertyDescriptor,
    Le = Te && !Oe.call({
        1 : 2
    },
    1),
    Ee = Le ?
    function(c) {
        var a = Te(this, c);
        return !! a && a.enumerable
    }: Oe,
    Pe = {
        f: Ee
    },
    Ce = {}.toString,
    Ae = function(c) {
        return Ce.call(c).slice(8, -1)
    },
    xe = "".split,
    ke = En(function() {
        return ! Object("z").propertyIsEnumerable(0)
    }) ?
    function(c) {
        return "String" == Ae(c) ? xe.call(c, "") : Object(c)
    }: Object,
    Me = function(c) {
        return ke(Sn(c))
    },
    Ie = Object.getOwnPropertyDescriptor,
    _e = Pn ? Ie: function(c, a) {
        if (c = Me(c), a = _n(a, !0), Mn) try {
            return Ie(c, a)
        } catch(v) {}
        return Qn(c, a) ? Nn(!Pe.f.call(c, a), c[a]) : void 0
    },
    De = {
        f: _e
    },
    Fe = /#|\.prototype\./,
    Ge = function(c, a) {
        var v = Re[Ne(c)];
        return v == ze ? !0 : v == Ve ? !1 : "function" == typeof a ? En(a) : !!a
    },
    Ne = Ge.normalize = function(c) {
        return String(c).replace(Fe, ".").toLowerCase()
    },
    Re = Ge.data = {},
    Ve = Ge.NATIVE = "N",
    ze = Ge.POLYFILL = "P",
    He = Ge,
    Ke = {},
    We = function(c) {
        if ("function" != typeof c) throw TypeError(String(c) + " is not a function");
        return c
    },
    qe = function(c, a, v) {
        if (We(c), void 0 === a) return c;
        switch (v) {
        case 0:
            return function() {
                return c.call(a)
            };
        case 1:
            return function(v) {
                return c.call(a, v)
            };
        case 2:
            return function(v, h) {
                return c.call(a, v, h)
            };
        case 3:
            return function(v, h, y) {
                return c.call(a, v, h, y)
            }
        }
        return function() {
            return c.apply(a, arguments)
        }
    },
    Be = De.f,
    Ue = function(c) {
        var a = function(a, v, h) {
            if (this instanceof c) {
                switch (arguments.length) {
                case 0:
                    return new c;
                case 1:
                    return new c(a);
                case 2:
                    return new c(a, v)
                }
                return new c(a, v, h)
            }
            return c.apply(this, arguments)
        };
        return a.prototype = c.prototype,
        a
    },
    Ye = function(c, a) {
        var v, h, y, g, w, b, S, j, O, T = c.target,
        L = c.global,
        E = c.stat,
        P = c.proto,
        C = L ? Ln: E ? Ln[T] : (Ln[T] || {}).prototype,
        A = L ? Ke: Ke[T] || (Ke[T] = {}),
        k = A.prototype;
        for (g in a) v = He(L ? g: T + (E ? ".": "#") + g, c.forced),
        h = !v && C && Qn(C, g),
        b = A[g],
        h && (c.noTargetGet ? (O = Be(C, g), S = O && O.value) : S = C[g]),
        w = h && S ? S: a[g],
        h && typeof b == typeof w || (j = c.bind && h ? qe(w, Ln) : c.wrap && h ? Ue(w) : P && "function" == typeof w ? qe(Function.call, w) : w, (c.sham || w && w.sham || b && b.sham) && Rn(j, "sham", !0), A[g] = j, P && (y = T + "Prototype", Qn(Ke, y) || Rn(Ke, y, {}), Ke[y][g] = w, c.real && k && !k[g] && Rn(k, g, w)))
    },
    Je = function(c) {
        return Object(Sn(c))
    },
    Xe = !En(function() {
        function c() {}
        return c.prototype.constructor = null,
        Object.getPrototypeOf(new c) !== c.prototype
    }),
    $e = ue("IE_PROTO"),
    Qe = Object.prototype,
    Ze = Xe ? Object.getPrototypeOf: function(c) {
        return c = Je(c),
        Qn(c, $e) ? c[$e] : "function" == typeof c.constructor && c instanceof c.constructor ? c.constructor.prototype: c instanceof Object ? Qe: null
    },
    tr = !!Object.getOwnPropertySymbols && !En(function() {
        return ! String(Symbol())
    }),
    nr = tr && !Symbol.sham && "symbol" == typeof Symbol.iterator,
    er = te("wks"),
    rr = Ln.Symbol,
    cr = nr ? rr: rr && rr.withoutSetter || ie,
    ur = function(c) {
        return Qn(er, c) || (er[c] = tr && Qn(rr, c) ? rr[c] : cr("Symbol." + c)),
        er[c]
    },
    ar = (ur("iterator"), !1); [].keys && (Se = [].keys(), "next" in Se ? (be = Ze(Ze(Se)), be !== Object.prototype && (we = be)) : ar = !0),
    void 0 == we && (we = {});
    var fr, sr = {
        IteratorPrototype: we,
        BUGGY_SAFARI_ITERATORS: ar
    },
    lr = Math.min,
    pr = function(c) {
        return c > 0 ? lr(bn(c), 9007199254740991) : 0
    },
    vr = Math.max,
    dr = Math.min,
    hr = function(c, a) {
        var v = bn(c);
        return 0 > v ? vr(v + a, 0) : dr(v, a)
    },
    yr = function(c) {
        return function(a, v, h) {
            var y, g = Me(a),
            w = pr(g.length),
            b = hr(h, w);
            if (c && v != v) {
                for (; w > b;) if (y = g[b++], y != y) return ! 0
            } else for (; w > b; b++) if ((c || b in g) && g[b] === v) return c || b || 0;
            return ! c && -1
        }
    },
    gr = {
        includes: yr(!0),
        indexOf: yr(!1)
    },
    mr = gr.indexOf,
    wr = function(c, a) {
        var v, h = Me(c),
        i = 0,
        y = [];
        for (v in h) ! Qn(ae, v) && Qn(h, v) && y.push(v);
        for (; a.length > i;) Qn(h, v = a[i++]) && (~mr(y, v) || y.push(v));
        return y
    },
    br = ["constructor", "hasOwnProperty", "isPrototypeOf", "propertyIsEnumerable", "toLocaleString", "toString", "valueOf"],
    Sr = Object.keys ||
    function(c) {
        return wr(c, br)
    },
    jr = Pn ? Object.defineProperties: function(c, a) {
        In(c);
        for (var v, h = Sr(a), y = h.length, g = 0; y > g;) Gn.f(c, v = h[g++], a[v]);
        return c
    },
    Or = function(c) {
        return "function" == typeof c ? c: void 0
    },
    Tr = function(c, a) {
        return arguments.length < 2 ? Or(Ke[c]) || Or(Ln[c]) : Ke[c] && Ke[c][a] || Ln[c] && Ln[c][a]
    },
    Lr = Tr("document", "documentElement"),
    Er = ">",
    Pr = "<",
    Cr = "prototype",
    Ar = "script",
    xr = ue("IE_PROTO"),
    kr = function() {},
    Mr = function(c) {
        return Pr + Ar + Er + c + Pr + "/" + Ar + Er
    },
    Ir = function(c) {
        c.write(Mr("")),
        c.close();
        var a = c.parentWindow.Object;
        return c = null,
        a
    },
    _r = function() {
        var c, a = kn("iframe"),
        v = "java" + Ar + ":";
        return a.style.display = "none",
        Lr.appendChild(a),
        a.src = String(v),
        c = a.contentWindow.document,
        c.open(),
        c.write(Mr("document.F=Object")),
        c.close(),
        c.F
    },
    Dr = function() {
        try {
            fr = document.domain && new ActiveXObject("htmlfile")
        } catch(c) {}
        Dr = fr ? Ir(fr) : _r();
        for (var a = br.length; a--;) delete Dr[Cr][br[a]];
        return Dr()
    };
    ae[xr] = !0;
    var Fr = Object.create ||
    function(c, a) {
        var v;
        return null !== c ? (kr[Cr] = In(c), v = new kr, kr[Cr] = null, v[xr] = c) : v = Dr(),
        void 0 === a ? v: jr(v, a)
    },
    Gr = ur("toStringTag"),
    Nr = {};
    Nr[Gr] = "z";
    var Rr = "[object z]" === String(Nr),
    Vr = ur("toStringTag"),
    zr = "Arguments" == Ae(function() {
        return arguments
    } ()),
    Hr = function(c, a) {
        try {
            return c[a]
        } catch(v) {}
    },
    Kr = Rr ? Ae: function(c) {
        var a, v, h;
        return void 0 === c ? "Undefined": null === c ? "Null": "string" == typeof(v = Hr(a = Object(c), Vr)) ? v: zr ? Ae(a) : "Object" == (h = Ae(a)) && "function" == typeof a.callee ? "Arguments": h
    },
    Wr = Rr ? {}.toString: function() {
        return "[object " + Kr(this) + "]"
    },
    qr = Gn.f,
    Br = ur("toStringTag"),
    Ur = function(c, a, v, h) {
        if (c) {
            var y = v ? c: c.prototype;
            Qn(y, Br) || qr(y, Br, {
                configurable: !0,
                value: a
            }),
            h && !Rr && Rn(y, "toString", Wr)
        }
    },
    Yr = {},
    Jr = sr.IteratorPrototype,
    Xr = function() {
        return this
    },
    $r = function(c, a, v) {
        var h = a + " Iterator";
        return c.prototype = Fr(Jr, {
            next: Nn(1, v)
        }),
        Ur(c, h, !1, !0),
        Yr[h] = Xr,
        c
    },
    Qr = function(c) {
        if (!Cn(c) && null !== c) throw TypeError("Can"t set " + String(c) + " as a prototype");
        return c
    },
    Zr = (Object.setPrototypeOf || ("__proto__" in {} ?
    function() {
        var c, a = !1,
        v = {};
        try {
            c = Object.getOwnPropertyDescriptor(Object.prototype, "__proto__").set,
            c.call(v, []),
            a = v instanceof Array
        } catch(h) {}
        return function(v, h) {
            return In(v),
            Qr(h),
            a ? c.call(v, h) : v.__proto__ = h,
            v
        }
    } () : void 0),
    function(c, a, v, h) {
        h && h.enumerable ? c[a] = v: Rn(c, a, v)
    }),
    to = sr.IteratorPrototype,
    no = sr.BUGGY_SAFARI_ITERATORS,
    eo = ur("iterator"),
    ro = "keys",
    oo = "values",
    io = "entries",
    co = function() {
        return this
    },
    uo = function(c, a, v, h, y, g, w) {
        $r(v, a, h);
        var b, S, j, O = function(c) {
            if (c === y && C) return C;
            if (!no && c in E) return E[c];
            switch (c) {
            case ro:
                return function() {
                    return new v(this, c)
                };
            case oo:
                return function() {
                    return new v(this, c)
                };
            case io:
                return function() {
                    return new v(this, c)
                }
            }
            return function() {
                return new v(this)
            }
        },
        T = a + " Iterator",
        L = !1,
        E = c.prototype,
        P = E[eo] || E["@@iterator"] || y && E[y],
        C = !no && P || O(y),
        A = "Array" == a ? E.entries || P: P;
        if (A && (b = Ze(A.call(new c)), to !== Object.prototype && b.next && (Ur(b, T, !0, !0), Yr[T] = co)), y == oo && P && P.name !== oo && (L = !0, C = function() {
            return P.call(this)
        }), w && E[eo] !== C && Rn(E, eo, C), Yr[a] = C, y) if (S = {
            values: O(oo),
            keys: g ? C: O(ro),
            entries: O(io)
        },
        w) for (j in S) ! no && !L && j in E || Zr(E, j, S[j]);
        else Ye({
            target: a,
            proto: !0,
            forced: no || L
        },
        S);
        return S
    },
    ao = On.charAt,
    fo = "String Iterator",
    so = je.set,
    lo = je.getterFor(fo);
    uo(String, "String",
    function(c) {
        so(this, {
            type: fo,
            string: String(c),
            index: 0
        })
    },
    function() {
        var c, a = lo(this),
        v = a.string,
        h = a.index;
        return h >= v.length ? {
            value: void 0,
            done: !0
        }: (c = ao(v, h), a.index += c.length, {
            value: c,
            done: !1
        })
    }); {
        var vo = "Array Iterator",
        ho = je.set,
        yo = je.getterFor(vo);
        uo(Array, "Array",
        function(c, a) {
            ho(this, {
                type: vo,
                target: Me(c),
                index: 0,
                kind: a
            })
        },
        function() {
            var c = yo(this),
            a = c.target,
            v = c.kind,
            h = c.index++;
            return ! a || h >= a.length ? (c.target = void 0, {
                value: void 0,
                done: !0
            }) : "keys" == v ? {
                value: h,
                done: !1
            }: "values" == v ? {
                value: a[h],
                done: !1
            }: {
                value: [h, a[h]],
                done: !1
            }
        },
        "values")
    }
    Yr.Arguments = Yr.Array;
    var go = {
        CSSRuleList: 0,
        CSSStyleDeclaration: 0,
        CSSValueList: 0,
        ClientRectList: 0,
        DOMRectList: 0,
        DOMStringList: 0,
        DOMTokenList: 1,
        DataTransferItemList: 0,
        FileList: 0,
        HTMLAllCollection: 0,
        HTMLCollection: 0,
        HTMLFormElement: 0,
        HTMLSelectElement: 0,
        MediaList: 0,
        MimeTypeArray: 0,
        NamedNodeMap: 0,
        NodeList: 1,
        PaintRequestList: 0,
        Plugin: 0,
        PluginArray: 0,
        SVGLengthList: 0,
        SVGNumberList: 0,
        SVGPathSegList: 0,
        SVGPointList: 0,
        SVGStringList: 0,
        SVGTransformList: 0,
        SourceBufferList: 0,
        StyleSheetList: 0,
        TextTrackCueList: 0,
        TextTrackList: 0,
        TouchList: 0
    },
    wo = ur("toStringTag");
    for (var bo in go) {
        var So = Ln[bo],
        jo = So && So.prototype;
        jo && Kr(jo) !== wo && Rn(jo, wo, bo),
        Yr[bo] = Yr.Array
    }
    var Oo = Ln.Promise,
    To = function(c, a, v) {
        for (var h in a) v && v.unsafe && c[h] ? c[h] = a[h] : Zr(c, h, a[h], v);
        return c
    },
    Lo = ur("species"),
    Eo = function(c) {
        var a = Tr(c),
        v = Gn.f;
        Pn && a && !a[Lo] && v(a, Lo, {
            configurable: !0,
            get: function() {
                return this
            }
        })
    },
    Po = function(c, a, v) {
        if (! (c instanceof a)) throw TypeError("Incorrect " + (v ? v + " ": "") + "invocation");
        return c
    },
    Co = ur("iterator"),
    Ao = Array.prototype,
    xo = function(c) {
        return void 0 !== c && (Yr.Array === c || Ao[Co] === c)
    },
    ko = ur("iterator"),
    Mo = function(c) {
        return void 0 != c ? c[ko] || c["@@iterator"] || Yr[Kr(c)] : void 0
    },
    Io = function(c, a, v, h) {
        try {
            return h ? a(In(v)[0], v[1]) : a(v)
        } catch(y) {
            var g = c["return"];
            throw void 0 !== g && In(g.call(c)),
            y
        }
    },
    _o = c(function(module) {
        var c = function(c, a) {
            this.stopped = c,
            this.result = a
        },
        a = module.exports = function(a, v, h, y, g) {
            var w, b, S, j, O, T, L, E = qe(v, h, y ? 2 : 1);
            if (g) w = a;
            else {
                if (b = Mo(a), "function" != typeof b) throw TypeError("Target is not iterable");
                if (xo(b)) {
                    for (S = 0, j = pr(a.length); j > S; S++) if (O = y ? E(In(L = a[S])[0], L[1]) : E(a[S]), O && O instanceof c) return O;
                    return new c(!1)
                }
                w = b.call(a)
            }
            for (T = w.next; ! (L = T.call(w)).done;) if (O = Io(w, E, L.value, y), "object" == typeof O && O && O instanceof c) return O;
            return new c(!1)
        };
        a.stop = function(a) {
            return new c(!0, a)
        }
    }),
    Do = ur("iterator"),
    Fo = !1;
    try {
        var Go = 0,
        No = {
            next: function() {
                return {
                    done: !!Go++
                }
            },
            "return": function() {
                Fo = !0
            }
        };
        No[Do] = function() {
            return this
        },
        Array.from(No,
        function() {
            throw 2
        })
    } catch(Ro) {}
    var Vo, zo, port, Ho = function(c, a) {
        if (!a && !Fo) return ! 1;
        var v = !1;
        try {
            var h = {};
            h[Do] = function() {
                return {
                    next: function() {
                        return {
                            done: v = !0
                        }
                    }
                }
            },
            c(h)
        } catch(y) {}
        return v
    },
    Ko = ur("species"),
    Wo = function(c, a) {
        var v, h = In(c).constructor;
        return void 0 === h || void 0 == (v = In(h)[Ko]) ? a: We(v)
    },
    qo = Tr("navigator", "userAgent") || "",
    Bo = /(iphone|ipod|ipad).*applewebkit/i.test(qo),
    Uo = Ln.location,
    Yo = Ln.setImmediate,
    Jo = Ln.clearImmediate,
    Xo = Ln.process,
    $o = Ln.MessageChannel,
    Qo = Ln.Dispatch,
    Zo = 0,
    ti = {},
    ni = "onreadystatechange",
    ei = function(c) {
        if (ti.hasOwnProperty(c)) {
            var a = ti[c];
            delete ti[c],
            a()
        }
    },
    ri = function(c) {
        return function() {
            ei(c)
        }
    },
    oi = function(c) {
        ei(c.data)
    },
    ii = function(c) {
        Ln.postMessage(c + "", Uo.protocol + "//" + Uo.host)
    };
    Yo && Jo || (Yo = function(c) {
        for (var a = [], i = 1; arguments.length > i;) a.push(arguments[i++]);
        return ti[++Zo] = function() { ("function" == typeof c ? c: Function(c)).apply(void 0, a)
        },
        Vo(Zo),
        Zo
    },
    Jo = function(c) {
        delete ti[c]
    },
    "process" == Ae(Xo) ? Vo = function(c) {
        Xo.nextTick(ri(c))
    }: Qo && Qo.now ? Vo = function(c) {
        Qo.now(ri(c))
    }: $o && !Bo ? (zo = new $o, port = zo.port2, zo.port1.onmessage = oi, Vo = qe(port.postMessage, port, 1)) : !Ln.addEventListener || "function" != typeof postMessage || Ln.importScripts || En(ii) || "file:" === Uo.protocol ? Vo = ni in kn("script") ?
    function(c) {
        Lr.appendChild(kn("script"))[ni] = function() {
            Lr.removeChild(this),
            ei(c)
        }
    }: function(c) {
        setTimeout(ri(c), 0)
    }: (Vo = ii, Ln.addEventListener("message", oi, !1)));
    var ci, ai, si, li, pi, vi, di, hi, yi = {
        set: Yo,
        clear: Jo
    },
    gi = De.f,
    mi = yi.set,
    wi = Ln.MutationObserver || Ln.WebKitMutationObserver,
    bi = Ln.process,
    Si = Ln.Promise,
    ji = "process" == Ae(bi),
    Oi = gi(Ln, "queueMicrotask"),
    Ti = Oi && Oi.value;
    Ti || (ci = function() {
        var c, a;
        for (ji && (c = bi.domain) && c.exit(); ai;) {
            a = ai.fn,
            ai = ai.next;
            try {
                a()
            } catch(v) {
                throw ai ? li() : si = void 0,
                v
            }
        }
        si = void 0,
        c && c.enter()
    },
    ji ? li = function() {
        bi.nextTick(ci)
    }: wi && !Bo ? (pi = !0, vi = document.createTextNode(""), new wi(ci).observe(vi, {
        characterData: !0
    }), li = function() {
        vi.data = pi = !pi
    }) : Si && Si.resolve ? (di = Si.resolve(void 0), hi = di.then, li = function() {
        hi.call(di, ci)
    }) : li = function() {
        mi.call(Ln, ci)
    });
    var Li, Ei, Pi = Ti ||
    function(c) {
        var a = {
            fn: c,
            next: void 0
        };
        si && (si.next = a),
        ai || (ai = a, li()),
        si = a
    },
    Ci = function(c) {
        var a, v;
        this.promise = new c(function(c, h) {
            if (void 0 !== a || void 0 !== v) throw TypeError("Bad Promise constructor");
            a = c,
            v = h
        }),
        this.resolve = We(a),
        this.reject = We(v)
    },
    Ai = function(c) {
        return new Ci(c)
    },
    xi = {
        f: Ai
    },
    ki = function(c, x) {
        if (In(c), Cn(x) && x.constructor === c) return x;
        var a = xi.f(c),
        v = a.resolve;
        return v(x),
        a.promise
    },
    Mi = function(c, a) {
        var v = Ln.console;
        v && v.error && (1 === arguments.length ? v.error(c) : v.error(c, a))
    },
    Ii = function(c) {
        try {
            return {
                error: !1,
                value: c()
            }
        } catch(a) {
            return {
                error: !0,
                value: a
            }
        }
    },
    _i = Ln.process,
    Di = _i && _i.versions,
    Fi = Di && Di.v8;
    Fi ? (Li = Fi.split("."), Ei = Li[0] + Li[1]) : qo && (Li = qo.match(/Edge\/(\d+)/), (!Li || Li[1] >= 74) && (Li = qo.match(/Chrome\/(\d+)/), Li && (Ei = Li[1])));
    var Gi, Ni, Ri, Vi = Ei && +Ei,
    zi = yi.set,
    Hi = ur("species"),
    Ki = "Promise",
    Wi = je.get,
    qi = je.set,
    Bi = je.getterFor(Ki),
    Ui = Oo,
    Yi = Ln.TypeError,
    Ji = Ln.document,
    Xi = Ln.process,
    $i = (Tr("fetch"), xi.f),
    Qi = $i,
    Zi = "process" == Ae(Xi),
    tc = !!(Ji && Ji.createEvent && Ln.dispatchEvent),
    nc = "unhandledrejection",
    ec = "rejectionhandled",
    rc = 0,
    oc = 1,
    ic = 2,
    cc = 1,
    uc = 2,
    ac = He(Ki,
    function() {
        var c = Yn(Ui) !== String(Ui);
        if (!c) {
            if (66 === Vi) return ! 0;
            if (!Zi && "function" != typeof PromiseRejectionEvent) return ! 0
        }
        if (!Ui.prototype["finally"]) return ! 0;
        if (Vi >= 51 && /native code/.test(Ui)) return ! 1;
        var a = Ui.resolve(1),
        v = function(c) {
            c(function() {},
            function() {})
        },
        h = a.constructor = {};
        return h[Hi] = v,
        !(a.then(function() {}) instanceof v)
    }),
    fc = ac || !Ho(function(c) {
        Ui.all(c)["catch"](function() {})
    }),
    sc = function(c) {
        var a;
        return Cn(c) && "function" == typeof(a = c.then) ? a: !1
    },
    lc = function(c, a, v) {
        if (!a.notified) {
            a.notified = !0;
            var h = a.reactions;
            Pi(function() {
                for (var y = a.value,
                g = a.state == oc,
                w = 0; h.length > w;) {
                    var b, S, j, O = h[w++],
                    T = g ? O.ok: O.fail,
                    L = O.resolve,
                    E = O.reject,
                    P = O.domain;
                    try {
                        T ? (g || (a.rejection === uc && hc(c, a), a.rejection = cc), T === !0 ? b = y: (P && P.enter(), b = T(y), P && (P.exit(), j = !0)), b === O.promise ? E(Yi("Promise-chain cycle")) : (S = sc(b)) ? S.call(b, L, E) : L(b)) : E(y)
                    } catch(C) {
                        P && !j && P.exit(),
                        E(C)
                    }
                }
                a.reactions = [],
                a.notified = !1,
                v && !a.rejection && vc(c, a)
            })
        }
    },
    pc = function(c, a, v) {
        var h, y;
        tc ? (h = Ji.createEvent("Event"), h.promise = a, h.reason = v, h.initEvent(c, !1, !0), Ln.dispatchEvent(h)) : h = {
            promise: a,
            reason: v
        },
        (y = Ln["on" + c]) ? y(h) : c === nc && Mi("Unhandled promise rejection", v)
    },
    vc = function(c, a) {
        zi.call(Ln,
        function() {
            var v, h = a.value,
            y = dc(a);
            if (y && (v = Ii(function() {
                Zi ? Xi.emit("unhandledRejection", h, c) : pc(nc, c, h)
            }), a.rejection = Zi || dc(a) ? uc: cc, v.error)) throw v.value
        })
    },
    dc = function(c) {
        return c.rejection !== cc && !c.parent
    },
    hc = function(c, a) {
        zi.call(Ln,
        function() {
            Zi ? Xi.emit("rejectionHandled", c) : pc(ec, c, a.value)
        })
    },
    yc = function(c, a, v, h) {
        return function(y) {
            c(a, v, y, h)
        }
    },
    gc = function(c, a, v, h) {
        a.done || (a.done = !0, h && (a = h), a.value = v, a.state = ic, lc(c, a, !0))
    },
    mc = function(c, a, v, h) {
        if (!a.done) {
            a.done = !0,
            h && (a = h);
            try {
                if (c === v) throw Yi("Promise can"t be resolved itself");
                var y = sc(v);
                y ? Pi(function() {
                    var h = {
                        done: !1
                    };
                    try {
                        y.call(v, yc(mc, c, h, a), yc(gc, c, h, a))
                    } catch(g) {
                        gc(c, h, g, a)
                    }
                }) : (a.value = v, a.state = oc, lc(c, a, !1))
            } catch(g) {
                gc(c, {
                    done: !1
                },
                g, a)
            }
        }
    };
    ac && (Ui = function(c) {
        Po(this, Ui, Ki),
        We(c),
        Gi.call(this);
        var a = Wi(this);
        try {
            c(yc(mc, this, a), yc(gc, this, a))
        } catch(v) {
            gc(this, a, v)
        }
    },
    Gi = function() {
        qi(this, {
            type: Ki,
            done: !1,
            notified: !1,
            parent: !1,
            reactions: [],
            rejection: !1,
            state: rc,
            value: void 0
        })
    },
    Gi.prototype = To(Ui.prototype, {
        then: function(c, a) {
            var v = Bi(this),
            h = $i(Wo(this, Ui));
            return h.ok = "function" == typeof c ? c: !0,
            h.fail = "function" == typeof a && a,
            h.domain = Zi ? Xi.domain: void 0,
            v.parent = !0,
            v.reactions.push(h),
            v.state != rc && lc(this, v, !1),
            h.promise
        },
        "catch": function(c) {
            return this.then(void 0, c)
        }
    }), Ni = function() {
        var c = new Gi,
        a = Wi(c);
        this.promise = c,
        this.resolve = yc(mc, c, a),
        this.reject = yc(gc, c, a)
    },
    xi.f = $i = function(c) {
        return c === Ui || c === Ri ? new Ni(c) : Qi(c)
    }),
    Ye({
        global: !0,
        wrap: !0,
        forced: ac
    },
    {
        Promise: Ui
    }),
    Ur(Ui, Ki, !1, !0),
    Eo(Ki),
    Ri = Tr(Ki),
    Ye({
        target: Ki,
        stat: !0,
        forced: ac
    },
    {
        reject: function(r) {
            var c = $i(this);
            return c.reject.call(void 0, r),
            c.promise
        }
    }),
    Ye({
        target: Ki,
        stat: !0,
        forced: Zn
    },
    {
        resolve: function(x) {
            return ki(this === Ri ? Ui: this, x)
        }
    }),
    Ye({
        target: Ki,
        stat: !0,
        forced: fc
    },
    {
        all: function(c) {
            var a = this,
            v = $i(a),
            h = v.resolve,
            y = v.reject,
            g = Ii(function() {
                var v = We(a.resolve),
                g = [],
                w = 0,
                b = 1;
                _o(c,
                function(c) {
                    var S = w++,
                    j = !1;
                    g.push(void 0),
                    b++,
                    v.call(a, c).then(function(c) {
                        j || (j = !0, g[S] = c, --b || h(g))
                    },
                    y)
                }),
                --b || h(g)
            });
            return g.error && y(g.value),
            v.promise
        },
        race: function(c) {
            var a = this,
            v = $i(a),
            h = v.reject,
            y = Ii(function() {
                var y = We(a.resolve);
                _o(c,
                function(c) {
                    y.call(a, c).then(v.resolve, h)
                })
            });
            return y.error && h(y.value),
            v.promise
        }
    }),
    Ye({
        target: "Promise",
        stat: !0
    },
    {
        allSettled: function(c) {
            var a = this,
            v = xi.f(a),
            h = v.resolve,
            y = v.reject,
            g = Ii(function() {
                var v = We(a.resolve),
                y = [],
                g = 0,
                w = 1;
                _o(c,
                function(c) {
                    var b = g++,
                    S = !1;
                    y.push(void 0),
                    w++,
                    v.call(a, c).then(function(c) {
                        S || (S = !0, y[b] = {
                            status: "fulfilled",
                            value: c
                        },
                        --w || h(y))
                    },
                    function(e) {
                        S || (S = !0, y[b] = {
                            status: "rejected",
                            reason: e
                        },
                        --w || h(y))
                    })
                }),
                --w || h(y)
            });
            return g.error && y(g.value),
            v.promise
        }
    });
    var wc = !!Oo && En(function() {
        Oo.prototype["finally"].call({
            then: function() {}
        },
        function() {})
    });
    Ye({
        target: "Promise",
        proto: !0,
        real: !0,
        forced: wc
    },
    {
        "finally": function(c) {
            var a = Wo(this, Tr("Promise")),
            v = "function" == typeof c;
            return this.then(v ?
            function(x) {
                return ki(a, c()).then(function() {
                    return x
                })
            }: c, v ?
            function(e) {
                return ki(a, c()).then(function() {
                    throw e
                })
            }: c)
        }
    });
    var bc = Ke.Promise,
    Sc = bc,
    jc = Sc,
    Oc = c(function(module) { !
        function(c, a) {
            module.exports ? module.exports = a() : this[c] = a()
        } ("$script",
        function() {
            function c(c, a) {
                for (var i = 0,
                v = c.length; v > i; ++i) if (!a(c[i])) return f;
                return 1
            }
            function a(a, v) {
                c(a,
                function(c) {
                    return v(c),
                    1
                })
            }
            function v(g, w, b) {
                function j(c) {
                    return c.call ? c() : T[c]
                }
                function O() {
                    if (!--k) {
                        T[A] = 1,
                        C && C();
                        for (var v in L) c(v.split("|"), j) && !a(L[v], j) && (L[v] = [])
                    }
                }
                g = g[S] ? g: [g];
                var P = w && w.call,
                C = P ? w: b,
                A = P ? g.join("") : w,
                k = g.length;
                return setTimeout(function() {
                    a(g,
                    function c(a, v) {
                        return null === a ? O() : (v || /^https?:\/\//.test(a) || !y || (a = -1 === a.indexOf(".js") ? y + a + ".js": y + a), E[a] ? 2 == E[a] ? O() : setTimeout(function() {
                            c(a, !0)
                        },
                        0) : (E[a] = 1, void h(a, O)))
                    })
                },
                0),
                v
            }
            function h(c, a) {
                var v, h = w.createElement("script");
                h.onload = h.onerror = h[O] = function() {
                    h[j] && !/^c|loade/.test(h[j]) || v || (h.onload = h[O] = null, v = 1, E[c] = 2, a())
                },
                h.async = 1,
                h.src = g ? c + ( - 1 === c.indexOf("?") ? "?": "&") + g: c,
                b.insertBefore(h, b.lastChild)
            }
            var y, g, w = document,
            b = w.getElementsByTagName("head")[0],
            f = !1,
            S = "push",
            j = "readyState",
            O = "onreadystatechange",
            T = {},
            L = {},
            E = {};
            return v.get = h,
            v.order = function(c, a, h) { !
                function y(s) {
                    s = c.shift(),
                    c.length ? v(s, y) : v(s, a, h)
                } ()
            },
            v.path = function(p) {
                y = p
            },
            v.urlArgs = function(c) {
                g = c
            },
            v.ready = function(h, y, req) {
                h = h[S] ? h: [h];
                var g = [];
                return ! a(h,
                function(c) {
                    T[c] || g[S](c)
                }) && c(h,
                function(c) {
                    return T[c]
                }) ? y() : !
                function(c) {
                    L[c] = L[c] || [],
                    L[c][S](y),
                    req && req(g)
                } (h.join("|")),
                v
            },
            v.done = function(c) {
                v([null], c)
            },
            v
        })
    }),
    Tc = Array.isArray ||
    function(c) {
        return "Array" == Ae(c)
    },
    Lc = ur("species"),
    Ec = function(c, a) {
        var v;
        return Tc(c) && (v = c.constructor, "function" != typeof v || v !== Array && !Tc(v.prototype) ? Cn(v) && (v = v[Lc], null === v && (v = void 0)) : v = void 0),
        new(void 0 === v ? Array: v)(0 === a ? 0 : a)
    },
    Pc = [].push,
    Cc = function(c) {
        var a = 1 == c,
        v = 2 == c,
        h = 3 == c,
        y = 4 == c,
        g = 6 == c,
        w = 5 == c || g;
        return function(b, S, j, O) {
            for (var T, L, E = Je(b), P = ke(E), C = qe(S, j, 3), A = pr(P.length), k = 0, M = O || Ec, I = a ? M(b, A) : v ? M(b, 0) : void 0; A > k; k++) if ((w || k in P) && (T = P[k], L = C(T, k, E), c)) if (a) I[k] = L;
            else if (L) switch (c) {
            case 3:
                return ! 0;
            case 5:
                return T;
            case 6:
                return k;
            case 2:
                Pc.call(I, T)
            } else if (y) return ! 1;
            return g ? -1 : h || y ? y: I
        }
    },
    Ac = {
        forEach: Cc(0),
        map: Cc(1),
        filter: Cc(2),
        some: Cc(3),
        every: Cc(4),
        find: Cc(5),
        findIndex: Cc(6)
    },
    xc = function(c, a) {
        var v = [][c];
        return !! v && En(function() {
            v.call(null, a ||
            function() {
                throw 1
            },
            1)
        })
    },
    kc = Object.defineProperty,
    Mc = {},
    Ic = function(c) {
        throw c
    },
    _c = function(c, a) {
        if (Qn(Mc, c)) return Mc[c];
        a || (a = {});
        var v = [][c],
        h = Qn(a, "ACCESSORS") ? a.ACCESSORS: !1,
        y = Qn(a, 0) ? a[0] : Ic,
        g = Qn(a, 1) ? a[1] : void 0;
        return Mc[c] = !!v && !En(function() {
            if (h && !Pn) return ! 0;
            var c = {
                length: -1
            };
            h ? kc(c, 1, {
                enumerable: !0,
                get: Ic
            }) : c[1] = 1,
            v.call(c, y, g)
        })
    },
    Dc = Ac.forEach,
    Fc = xc("forEach"),
    Gc = _c("forEach"),
    Nc = Fc && Gc ? [].forEach: function(c) {
        return Dc(this, c, arguments.length > 1 ? arguments[1] : void 0)
    };
    Ye({
        target: "Array",
        proto: !0,
        forced: [].forEach != Nc
    },
    {
        forEach: Nc
    });
    var Rc = function(c) {
        return Ke[c + "Prototype"]
    },
    Vc = Rc("Array").forEach,
    zc = Vc,
    Hc = Array.prototype,
    Kc = {
        DOMTokenList: !0,
        NodeList: !0
    },
    Wc = function(c) {
        var a = c.forEach;
        return c === Hc || c instanceof Array && a === Hc.forEach || Kc.hasOwnProperty(Kr(c)) ? zc: a
    },
    qc = Wc;
    "undefined" == typeof window.lagouSenseCallbackList && (window.lagouSenseCallbackList = []),
    "undefined" == typeof window.senseScriptLoadLock && (window.senseScriptLoadLock = !1);
    var Bc = {}.propertyIsEnumerable,
    Uc = Object.getOwnPropertyDescriptor,
    Yc = Uc && !Bc.call({
        1 : 2
    },
    1),
    Jc = Yc ?
    function(c) {
        var a = Uc(this, c);
        return !! a && a.enumerable
    }: Bc,
    Xc = {
        f: Jc
    },
    $c = {}.toString,
    Qc = function(c) {
        return $c.call(c).slice(8, -1)
    },
    Zc = "".split,
    tu = S(function() {
        return ! Object("z").propertyIsEnumerable(0)
    }) ?
    function(c) {
        return "String" == Qc(c) ? Zc.call(c, "") : Object(c)
    }: Object,
    nu = function(c) {
        if (void 0 == c) throw TypeError("Can"t call method on " + c);
        return c
    },
    eu = function(c) {
        return tu(nu(c))
    },
    ru = Object.getOwnPropertyDescriptor,
    ou = j ? ru: function(c, a) {
        if (c = eu(c), a = A(a, !0), P) try {
            return ru(c, a)
        } catch(v) {}
        return F(c, a) ? I(!Xc.f.call(c, a), c[a]) : void 0
    },
    iu = {
        f: ou
    },
    cu = b,
    uu = function(c) {
        return "function" == typeof c ? c: void 0
    },
    au = function(c, a) {
        return arguments.length < 2 ? uu(cu[c]) || uu(b[c]) : cu[c] && cu[c][a] || b[c] && b[c][a]
    },
    fu = Math.ceil,
    su = Math.floor,
    lu = function(c) {
        return isNaN(c = +c) ? 0 : (c > 0 ? su: fu)(c)
    },
    pu = Math.min,
    vu = function(c) {
        return c > 0 ? pu(lu(c), 9007199254740991) : 0
    },
    hu = Math.max,
    yu = Math.min,
    gu = function(c, a) {
        var v = lu(c);
        return 0 > v ? hu(v + a, 0) : yu(v, a)
    },
    mu = function(c) {
        return function(a, v, h) {
            var y, g = eu(a),
            w = vu(g.length),
            b = gu(h, w);
            if (c && v != v) {
                for (; w > b;) if (y = g[b++], y != y) return ! 0
            } else for (; w > b; b++) if ((c || b in g) && g[b] === v) return c || b || 0;
            return ! c && -1
        }
    },
    wu = {
        includes: mu(!0),
        indexOf: mu(!1)
    },
    bu = wu.indexOf,
    Su = function(c, a) {
        var v, h = eu(c),
        i = 0,
        y = [];
        for (v in h) ! F(nn, v) && F(h, v) && y.push(v);
        for (; a.length > i;) F(h, v = a[i++]) && (~bu(y, v) || y.push(v));
        return y
    },
    ju = ["constructor", "hasOwnProperty", "isPrototypeOf", "propertyIsEnumerable", "toLocaleString", "toString", "valueOf"],
    Ou = ju.concat("length", "prototype"),
    Tu = Object.getOwnPropertyNames ||
    function(c) {
        return Su(c, Ou)
    },
    Lu = {
        f: Tu
    },
    Eu = Object.getOwnPropertySymbols,
    Pu = {
        f: Eu
    },
    Cu = au("Reflect", "ownKeys") ||
    function(c) {
        var a = Lu.f(C(c)),
        v = Pu.f;
        return v ? a.concat(v(c)) : a
    },
    Au = function(c, a) {
        for (var v = Cu(a), h = M.f, y = iu.f, i = 0; i < v.length; i++) {
            var g = v[i];
            F(c, g) || h(c, g, y(a, g))
        }
    },
    xu = /#|\.prototype\./,
    ku = function(c, a) {
        var v = Iu[Mu(c)];
        return v == Du ? !0 : v == _u ? !1 : "function" == typeof a ? S(a) : !!a
    },
    Mu = ku.normalize = function(c) {
        return String(c).replace(xu, ".").toLowerCase()
    },
    Iu = ku.data = {},
    _u = ku.NATIVE = "N",
    Du = ku.POLYFILL = "P",
    Fu = ku,
    Gu = iu.f,
    Nu = function(c, a) {
        var v, h, y, g, w, S, j = c.target,
        O = c.global,
        T = c.stat;
        if (h = O ? b: T ? b[j] || G(j, {}) : (b[j] || {}).prototype) for (y in a) {
            if (w = a[y], c.noTargetGet ? (S = Gu(h, y), g = S && S.value) : g = h[y], v = Fu(O ? y: j + (T ? ".": "#") + y, c.forced), !v && void 0 !== g) {
                if (typeof w == typeof g) continue;
                Au(w, g)
            } (c.sham || g && g.sham) && _(w, "sham", !0),
            pn(h, y, w, c)
        }
    },
    Ru = function(c, a) {
        var v = [][c];
        return !! v && S(function() {
            v.call(null, a ||
            function() {
                throw 1
            },
            1)
        })
    },
    Vu = [].join,
    zu = tu != Object,
    Hu = Ru("join", ",");
    Nu({
        target: "Array",
        proto: !0,
        forced: zu || !Hu
    },
    {
        join: function(c) {
            return Vu.call(eu(this), void 0 === c ? ",": c)
        }
    });
    var Ku = function(c) {
        if (window.lagouSenseCallbackList.push(c), !window.senseScriptLoadLock) {
            window.senseScriptLoadLock = !0;
            var v = "undefined" != typeof window.LaGouCaptchaSenseClass;
            return v ? (window.senseScriptLoadLock = !1, void c()) : void y(function(c) {
                var v = "//www.lgstatic.com/lg-static-fed/common/static/js/sense/captchaClass.sense.1.0.0.js";
                if (1 === (null === c || void 0 === c ? void 0 : c.state)) {
                    var h, y, g = null === c || void 0 === c ? void 0 : null === (h = c.content) || void 0 === h ? void 0 : null === (y = h.data) || void 0 === y ? void 0 : y.version;
                    v = "//www.lgstatic.com/lg-static-fed/common/static/js/sense/captchaClass.sense.".concat(g || "1.0.0", ".js")
                }
                Oc(["".concat(v, "?v=") + (new Date).getTime()],
                function() {
                    window.senseScriptLoadLock = !1,
                    a()
                })
            },
            "senseCaptchaClass")
        }
    },
    Wu = function() {
        var c = "undefined" != typeof window.LaGouCaptchaGetSenseKey;
        return new jc(function(a) {
            c ? a() : y(function(c) {
                var v = "//www.lgstatic.com/lg-static-fed/common/static/js/sense/senseGetCaptchaKey.sense.1.0.0.js";
                if (1 === (null === c || void 0 === c ? void 0 : c.state)) {
                    var h, y, g = null === c || void 0 === c ? void 0 : null === (h = c.content) || void 0 === h ? void 0 : null === (y = h.data) || void 0 === y ? void 0 : y.version;
                    v = "//www.lgstatic.com/lg-static-fed/common/static/js/sense/senseGetCaptchaKey.sense.".concat(g || "1.0.0", ".js")
                }
                Oc(["".concat(v, "?v=") + (new Date).getTime()],
                function() {
                    a()
                })
            },
            "senseGetCaptchaKey")
        })
    };
    exports.captchaGetSenseKey = Wu,
    exports.defaults = Ku
});
/*!common/widgets/passport/common/js/sense.js*/
;
define("common/widgets/passport/common/js/sense", ["require", "exports", "module", "common/static/js/base-captcha/index"],
function(require, exports, module) {
    function a(a) {
        $.lgAjax({
            type: "GET",
            url: GLOBAL_DOMAIN.pctx + "/verify/getStyle.json",
            dataType: "jsonp",
            jsonp: "jsoncallback"
        }).done(function(c) {
            a(c.content.data.verifyStyle)
        }).fail(function(c) {
            var y = JSON.parse(c.responseText);
            a(y.content.data.verifyStyle)
        })
    }
    var c, y, v = require("common/static/js/base-captcha/index").defaults,
    S = [],
    g = [];
    a(function(a) {
        return verifyStyle = a,
        "nolagou" == verifyStyle || "nolagou_tencent" == verifyStyle ? (y = !0, void v(function() {
            c = new LaGouCaptchaSenseClass({
                isGtSense: "nolagou" === verifyStyle,
                isTcSense: "nolagou_tencent" === verifyStyle,
                gtAppId: "66442f2f720bfc86799932d8ad2eb6c7",
                tcAppId: "2088474689",
                errorCallback: function() {
                    window.location.reload()
                }
            }),
            S.forEach(function(a) {
                a && a(c)
            })
        })) : void("lagou" == verifyStyle && (y = !1, g.forEach(function(a) {
            a && a()
        })))
    }),
    module.exports = function(a, v) {
        return "undefined" == typeof y ? (S.push(a), void g.push(v)) : y && c ? void a(c) : y && !c ? void S.push(a) : void v()
    }
});
/*!common/widgets/passport/dep/socketio-java/socket.other.js*/
; !
function(f) {
    if ("object" == typeof exports && "undefined" != typeof module) module.exports = f();
    else if ("function" == typeof define && define.amd) define("common/widgets/passport/dep/socketio-java/socket.other", [], f);
    else {
        var a;
        a = "undefined" != typeof window ? window: "undefined" != typeof global ? global: "undefined" != typeof self ? self: this,
        a.io = f()
    }
} (function() {
    var define;
    return function e(t, n, r) {
        function s(o, u) {
            if (!n[o]) {
                if (!t[o]) {
                    var a = "function" == typeof require && require;
                    if (!u && a) return a(o, !0);
                    if (i) return i(o, !0);
                    var f = new Error("Cannot find module "" + o + """);
                    throw f.code = "MODULE_NOT_FOUND",
                    f
                }
                var l = n[o] = {
                    exports: {}
                };
                t[o][0].call(l.exports,
                function(e) {
                    var n = t[o][1][e];
                    return s(n ? n: e)
                },
                l, l.exports, e, t, n, r)
            }
            return n[o].exports
        }
        for (var i = "function" == typeof require && require,
        o = 0; o < r.length; o++) s(r[o]);
        return s
    } ({
        1 : [function(a, module, exports) {
            function c(a, c) {
                "object" == typeof a && (c = a, a = void 0),
                c = c || {};
                var y, w = h(a),
                k = w.source,
                A = w.id,
                B = w.path,
                C = v[A] && B in v[A].nsps,
                S = c.forceNew || c["force new connection"] || !1 === c.multiplex || C;
                return S ? (b("ignoring socket cache for %s", k), y = g(k, c)) : (v[A] || (b("new io instance for %s", k), v[A] = g(k, c)), y = v[A]),
                y.socket(w.path)
            }
            var h = a("./url"),
            y = a("socket.io-parser"),
            g = a("./manager"),
            b = a("debug")("socket.io-client");
            module.exports = exports = c;
            var v = exports.managers = {};
            exports.protocol = y.protocol,
            exports.connect = c,
            exports.Manager = a("./manager"),
            exports.Socket = a("./socket")
        },
        {
            "./manager": 2,
            "./socket": 4,
            "./url": 5,
            debug: 14,
            "socket.io-parser": 41
        }],
        2 : [function(a, module) {
            function c(a, h) {
                return this instanceof c ? (a && "object" == typeof a && (h = a, a = void 0), h = h || {},
                h.path = h.path || "/socket.io", this.nsps = {},
                this.subs = [], this.opts = h, this.reconnection(h.reconnection !== !1), this.reconnectionAttempts(h.reconnectionAttempts || 1 / 0), this.reconnectionDelay(h.reconnectionDelay || 1e3), this.reconnectionDelayMax(h.reconnectionDelayMax || 5e3), this.randomizationFactor(h.randomizationFactor || .5), this.backoff = new B({
                    min: this.reconnectionDelay(),
                    max: this.reconnectionDelayMax(),
                    jitter: this.randomizationFactor()
                }), this.timeout(null == h.timeout ? 2e4: h.timeout), this.readyState = "closed", this.uri = a, this.connecting = [], this.lastPing = null, this.encoding = !1, this.packetBuffer = [], this.encoder = new b.Encoder, this.decoder = new b.Decoder, this.autoConnect = h.autoConnect !== !1, void(this.autoConnect && this.open())) : new c(a, h)
            }
            var h = a("engine.io-client"),
            y = a("./socket"),
            g = a("component-emitter"),
            b = a("socket.io-parser"),
            v = a("./on"),
            w = a("component-bind"),
            k = a("debug")("socket.io-client:manager"),
            A = a("indexof"),
            B = a("backo2"),
            C = Object.prototype.hasOwnProperty;
            module.exports = c,
            c.prototype.emitAll = function() {
                this.emit.apply(this, arguments);
                for (var a in this.nsps) C.call(this.nsps, a) && this.nsps[a].emit.apply(this.nsps[a], arguments)
            },
            c.prototype.updateSocketIds = function() {
                for (var a in this.nsps) C.call(this.nsps, a) && (this.nsps[a].id = this.engine.id)
            },
            g(c.prototype),
            c.prototype.reconnection = function(a) {
                return arguments.length ? (this._reconnection = !!a, this) : this._reconnection
            },
            c.prototype.reconnectionAttempts = function(a) {
                return arguments.length ? (this._reconnectionAttempts = a, this) : this._reconnectionAttempts
            },
            c.prototype.reconnectionDelay = function(a) {
                return arguments.length ? (this._reconnectionDelay = a, this.backoff && this.backoff.setMin(a), this) : this._reconnectionDelay
            },
            c.prototype.randomizationFactor = function(a) {
                return arguments.length ? (this._randomizationFactor = a, this.backoff && this.backoff.setJitter(a), this) : this._randomizationFactor
            },
            c.prototype.reconnectionDelayMax = function(a) {
                return arguments.length ? (this._reconnectionDelayMax = a, this.backoff && this.backoff.setMax(a), this) : this._reconnectionDelayMax
            },
            c.prototype.timeout = function(a) {
                return arguments.length ? (this._timeout = a, this) : this._timeout
            },
            c.prototype.maybeReconnectOnOpen = function() { ! this.reconnecting && this._reconnection && 0 === this.backoff.attempts && this.reconnect()
            },
            c.prototype.open = c.prototype.connect = function(a) {
                if (k("readyState %s", this.readyState), ~this.readyState.indexOf("open")) return this;
                k("opening %s", this.uri),
                this.engine = h(this.uri, this.opts);
                var c = this.engine,
                y = this;
                this.readyState = "opening",
                this.skipReconnect = !1;
                var g = v(c, "open",
                function() {
                    y.onopen(),
                    a && a()
                }),
                b = v(c, "error",
                function(c) {
                    if (k("connect_error"), y.cleanup(), y.readyState = "closed", y.emitAll("connect_error", c), a) {
                        var h = new Error("Connection error");
                        h.data = c,
                        a(h)
                    } else y.maybeReconnectOnOpen()
                });
                if (!1 !== this._timeout) {
                    var w = this._timeout;
                    k("connect attempt will timeout after %d", w);
                    var A = setTimeout(function() {
                        k("connect attempt timed out after %d", w),
                        g.destroy(),
                        c.close(),
                        c.emit("error", "timeout"),
                        y.emitAll("connect_timeout", w)
                    },
                    w);
                    this.subs.push({
                        destroy: function() {
                            clearTimeout(A)
                        }
                    })
                }
                return this.subs.push(g),
                this.subs.push(b),
                this
            },
            c.prototype.onopen = function() {
                k("open"),
                this.cleanup(),
                this.readyState = "open",
                this.emit("open");
                var a = this.engine;
                this.subs.push(v(a, "data", w(this, "ondata"))),
                this.subs.push(v(a, "ping", w(this, "onping"))),
                this.subs.push(v(a, "pong", w(this, "onpong"))),
                this.subs.push(v(a, "error", w(this, "onerror"))),
                this.subs.push(v(a, "close", w(this, "onclose"))),
                this.subs.push(v(this.decoder, "decoded", w(this, "ondecoded")))
            },
            c.prototype.onping = function() {
                this.lastPing = new Date,
                this.emitAll("ping")
            },
            c.prototype.onpong = function() {
                this.emitAll("pong", new Date - this.lastPing)
            },
            c.prototype.ondata = function(a) {
                this.decoder.add(a)
            },
            c.prototype.ondecoded = function(a) {
                this.emit("packet", a)
            },
            c.prototype.onerror = function(a) {
                k("error", a),
                this.emitAll("error", a)
            },
            c.prototype.socket = function(a) {
                function c() {~A(g.connecting, h) || g.connecting.push(h)
                }
                var h = this.nsps[a];
                if (!h) {
                    h = new y(this, a),
                    this.nsps[a] = h;
                    var g = this;
                    h.on("connecting", c),
                    h.on("connect",
                    function() {
                        h.id = g.engine.id
                    }),
                    this.autoConnect && c()
                }
                return h
            },
            c.prototype.destroy = function(a) {
                var c = A(this.connecting, a);~c && this.connecting.splice(c, 1),
                this.connecting.length || this.close()
            },
            c.prototype.packet = function(a) {
                k("writing packet %j", a);
                var c = this;
                c.encoding ? c.packetBuffer.push(a) : (c.encoding = !0, this.encoder.encode(a,
                function(h) {
                    for (var i = 0; i < h.length; i++) c.engine.write(h[i], a.options);
                    c.encoding = !1,
                    c.processPacketQueue()
                }))
            },
            c.prototype.processPacketQueue = function() {
                if (this.packetBuffer.length > 0 && !this.encoding) {
                    var a = this.packetBuffer.shift();
                    this.packet(a)
                }
            },
            c.prototype.cleanup = function() {
                k("cleanup");
                for (var a; a = this.subs.shift();) a.destroy();
                this.packetBuffer = [],
                this.encoding = !1,
                this.lastPing = null,
                this.decoder.destroy()
            },
            c.prototype.close = c.prototype.disconnect = function() {
                k("disconnect"),
                this.skipReconnect = !0,
                this.reconnecting = !1,
                "opening" == this.readyState && this.cleanup(),
                this.backoff.reset(),
                this.readyState = "closed",
                this.engine && this.engine.close()
            },
            c.prototype.onclose = function(a) {
                k("onclose"),
                this.cleanup(),
                this.backoff.reset(),
                this.readyState = "closed",
                this.emit("close", a),
                this._reconnection && !this.skipReconnect && this.reconnect()
            },
            c.prototype.reconnect = function() {
                if (this.reconnecting || this.skipReconnect) return this;
                var a = this;
                if (this.backoff.attempts >= this._reconnectionAttempts) k("reconnect failed"),
                this.backoff.reset(),
                this.emitAll("reconnect_failed"),
                this.reconnecting = !1;
                else {
                    var c = this.backoff.duration();
                    k("will wait %dms before reconnect attempt", c),
                    this.reconnecting = !0;
                    var h = setTimeout(function() {
                        a.skipReconnect || (k("attempting reconnect"), a.emitAll("reconnect_attempt", a.backoff.attempts), a.emitAll("reconnecting", a.backoff.attempts), a.skipReconnect || a.open(function(c) {
                            c ? (k("reconnect attempt error"), a.reconnecting = !1, a.reconnect(), a.emitAll("reconnect_error", c.data)) : (k("reconnect success"), a.onreconnect())
                        }))
                    },
                    c);
                    this.subs.push({
                        destroy: function() {
                            clearTimeout(h)
                        }
                    })
                }
            },
            c.prototype.onreconnect = function() {
                var a = this.backoff.attempts;
                this.reconnecting = !1,
                this.backoff.reset(),
                this.updateSocketIds(),
                this.emitAll("reconnect", a)
            }
        },
        {
            "./on": 3,
            "./socket": 4,
            backo2: 8,
            "component-bind": 11,
            "component-emitter": 12,
            debug: 14,
            "engine.io-client": 16,
            indexof: 33,
            "socket.io-parser": 41
        }],
        3 : [function(a, module) {
            function c(a, c, h) {
                return a.on(c, h),
                {
                    destroy: function() {
                        a.removeListener(c, h)
                    }
                }
            }
            module.exports = c
        },
        {}],
        4 : [function(a, module, exports) {
            function c(a, c) {
                this.io = a,
                this.nsp = c,
                this.json = this,
                this.ids = 0,
                this.acks = {},
                this.receiveBuffer = [],
                this.sendBuffer = [],
                this.connected = !1,
                this.disconnected = !0,
                this.io.autoConnect && this.open()
            }
            var h = a("socket.io-parser"),
            y = a("component-emitter"),
            g = a("to-array"),
            b = a("./on"),
            v = a("component-bind"),
            w = a("debug")("socket.io-client:socket"),
            k = a("has-binary");
            module.exports = exports = c;
            var A = {
                connect: 1,
                connect_error: 1,
                connect_timeout: 1,
                connecting: 1,
                disconnect: 1,
                error: 1,
                reconnect: 1,
                reconnect_attempt: 1,
                reconnect_failed: 1,
                reconnect_error: 1,
                reconnecting: 1,
                ping: 1,
                pong: 1
            },
            B = y.prototype.emit;
            y(c.prototype),
            c.prototype.subEvents = function() {
                if (!this.subs) {
                    var a = this.io;
                    this.subs = [b(a, "open", v(this, "onopen")), b(a, "packet", v(this, "onpacket")), b(a, "close", v(this, "onclose"))]
                }
            },
            c.prototype.open = c.prototype.connect = function() {
                return this.connected ? this: (this.subEvents(), this.io.open(), "open" == this.io.readyState && this.onopen(), this.emit("connecting"), this)
            },
            c.prototype.send = function() {
                var a = g(arguments);
                return a.unshift("message"),
                this.emit.apply(this, a),
                this
            },
            c.prototype.emit = function(a) {
                if (A.hasOwnProperty(a)) return B.apply(this, arguments),
                this;
                var c = g(arguments),
                y = h.EVENT;
                k(c) && (y = h.BINARY_EVENT);
                var b = {
                    type: y,
                    data: c
                };
                return b.options = {},
                b.options.compress = !this.flags || !1 !== this.flags.compress,
                "function" == typeof c[c.length - 1] && (w("emitting packet with ack id %d", this.ids), this.acks[this.ids] = c.pop(), b.id = this.ids++),
                this.connected ? this.packet(b) : this.sendBuffer.push(b),
                delete this.flags,
                this
            },
            c.prototype.packet = function(a) {
                a.nsp = this.nsp,
                this.io.packet(a)
            },
            c.prototype.onopen = function() {
                w("transport is open - connecting"),
                "/" != this.nsp && this.packet({
                    type: h.CONNECT
                })
            },
            c.prototype.onclose = function(a) {
                w("close (%s)", a),
                this.connected = !1,
                this.disconnected = !0,
                delete this.id,
                this.emit("disconnect", a)
            },
            c.prototype.onpacket = function(a) {
                if (a.nsp == this.nsp) switch (a.type) {
                case h.CONNECT:
                    this.onconnect();
                    break;
                case h.EVENT:
                    this.onevent(a);
                    break;
                case h.BINARY_EVENT:
                    this.onevent(a);
                    break;
                case h.ACK:
                    this.onack(a);
                    break;
                case h.BINARY_ACK:
                    this.onack(a);
                    break;
                case h.DISCONNECT:
                    this.ondisconnect();
                    break;
                case h.ERROR:
                    this.emit("error", a.data)
                }
            },
            c.prototype.onevent = function(a) {
                var c = a.data || [];
                w("emitting event %j", c),
                null != a.id && (w("attaching ack callback to event"), c.push(this.ack(a.id))),
                this.connected ? B.apply(this, c) : this.receiveBuffer.push(c)
            },
            c.prototype.ack = function(a) {
                var c = this,
                y = !1;
                return function() {
                    if (!y) {
                        y = !0;
                        var b = g(arguments);
                        w("sending ack %j", b);
                        var v = k(b) ? h.BINARY_ACK: h.ACK;
                        c.packet({
                            type: v,
                            id: a,
                            data: b
                        })
                    }
                }
            },
            c.prototype.onack = function(a) {
                var c = this.acks[a.id];
                "function" == typeof c ? (w("calling ack %s with %j", a.id, a.data), c.apply(this, a.data), delete this.acks[a.id]) : w("bad ack %s", a.id)
            },
            c.prototype.onconnect = function() {
                this.connected = !0,
                this.disconnected = !1,
                this.emit("connect"),
                this.emitBuffered()
            },
            c.prototype.emitBuffered = function() {
                var i;
                for (i = 0; i < this.receiveBuffer.length; i++) B.apply(this, this.receiveBuffer[i]);
                for (this.receiveBuffer = [], i = 0; i < this.sendBuffer.length; i++) this.packet(this.sendBuffer[i]);
                this.sendBuffer = []
            },
            c.prototype.ondisconnect = function() {
                w("server disconnect (%s)", this.nsp),
                this.destroy(),
                this.onclose("io server disconnect")
            },
            c.prototype.destroy = function() {
                if (this.subs) {
                    for (var i = 0; i < this.subs.length; i++) this.subs[i].destroy();
                    this.subs = null
                }
                this.io.destroy(this)
            },
            c.prototype.close = c.prototype.disconnect = function() {
                return this.connected && (w("performing disconnect (%s)", this.nsp), this.packet({
                    type: h.DISCONNECT
                })),
                this.destroy(),
                this.connected && this.onclose("io client disconnect"),
                this
            },
            c.prototype.compress = function(a) {
                return this.flags = this.flags || {},
                this.flags.compress = a,
                this
            }
        },
        {
            "./on": 3,
            "component-bind": 11,
            "component-emitter": 12,
            debug: 14,
            "has-binary": 31,
            "socket.io-parser": 41,
            "to-array": 44
        }],
        5 : [function(a, module) { (function(c) {
                function h(a, h) {
                    var b = a,
                    h = h || c.location;
                    null == a && (a = h.protocol + "//" + h.host),
                    "string" == typeof a && ("/" == a.charAt(0) && (a = "/" == a.charAt(1) ? h.protocol + a: h.host + a), /^(https?|wss?):\/\//.test(a) || (g("protocol-less url %s", a), a = "undefined" != typeof h ? h.protocol + "//" + a: "https://" + a), g("parse %s", a), b = y(a)),
                    b.port || (/^(http|ws)$/.test(b.protocol) ? b.port = "80": /^(http|ws)s$/.test(b.protocol) && (b.port = "443")),
                    b.path = b.path || "/";
                    var v = -1 !== b.host.indexOf(":"),
                    w = v ? "[" + b.host + "]": b.host;
                    return b.id = b.protocol + "://" + w + ":" + b.port,
                    b.href = b.protocol + "://" + w + (h && h.port == b.port ? "": ":" + b.port),
                    b
                }
                var y = a("parseuri"),
                g = a("debug")("socket.io-client:url");
                module.exports = h
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            debug: 14,
            parseuri: 39
        }],
        6 : [function(a, module) {
            function c(a, c, y) {
                function g(a, h) {
                    if (g.count <= 0) throw new Error("after called too many times"); --g.count,
                    a ? (b = !0, c(a), c = y) : 0 !== g.count || b || c(null, h)
                }
                var b = !1;
                return y = y || h,
                g.count = a,
                0 === a ? c() : g
            }
            function h() {}
            module.exports = c
        },
        {}],
        7 : [function(a, module) {
            module.exports = function(a, c, h) {
                var y = a.byteLength;
                if (c = c || 0, h = h || y, a.slice) return a.slice(c, h);
                if (0 > c && (c += y), 0 > h && (h += y), h > y && (h = y), c >= y || c >= h || 0 === y) return new ArrayBuffer(0);
                for (var g = new Uint8Array(a), b = new Uint8Array(h - c), i = c, v = 0; h > i; i++, v++) b[v] = g[i];
                return b.buffer
            }
        },
        {}],
        8 : [function(a, module) {
            function c(a) {
                a = a || {},
                this.ms = a.min || 100,
                this.max = a.max || 1e4,
                this.factor = a.factor || 2,
                this.jitter = a.jitter > 0 && a.jitter <= 1 ? a.jitter: 0,
                this.attempts = 0
            }
            module.exports = c,
            c.prototype.duration = function() {
                var a = this.ms * Math.pow(this.factor, this.attempts++);
                if (this.jitter) {
                    var c = Math.random(),
                    h = Math.floor(c * this.jitter * a);
                    a = 0 == (1 & Math.floor(10 * c)) ? a - h: a + h
                }
                return 0 | Math.min(a, this.max)
            },
            c.prototype.reset = function() {
                this.attempts = 0
            },
            c.prototype.setMin = function(a) {
                this.ms = a
            },
            c.prototype.setMax = function(a) {
                this.max = a
            },
            c.prototype.setJitter = function(a) {
                this.jitter = a
            }
        },
        {}],
        9 : [function(a, module, exports) { !
            function(a) {
                "use strict";
                exports.encode = function(c) {
                    var i, h = new Uint8Array(c),
                    y = h.buffer.byteLength,
                    g = "";
                    for (i = 0; y > i; i += 3) g += a[h.buffer[i] >> 2],
                    g += a[(3 & h.buffer[i]) << 4 | h.buffer[i + 1] >> 4],
                    g += a[(15 & h.buffer[i + 1]) << 2 | h.buffer[i + 2] >> 6],
                    g += a[63 & h.buffer[i + 2]];
                    return y % 3 === 2 ? g = g.substring(0, g.length - 1) + "=": y % 3 === 1 && (g = g.substring(0, g.length - 2) + "=="),
                    g
                },
                exports.decode = function(c) {
                    var i, h, y, g, b, v = .75 * c.length,
                    w = c.length,
                    p = 0;
                    "=" === c[c.length - 1] && (v--, "=" === c[c.length - 2] && v--);
                    var k = new ArrayBuffer(v),
                    A = new Uint8Array(k);
                    for (i = 0; w > i; i += 4) h = a.indexOf(c[i]),
                    y = a.indexOf(c[i + 1]),
                    g = a.indexOf(c[i + 2]),
                    b = a.indexOf(c[i + 3]),
                    A[p++] = h << 2 | y >> 4,
                    A[p++] = (15 & y) << 4 | g >> 2,
                    A[p++] = (3 & g) << 6 | 63 & b;
                    return k
                }
            } ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/")
        },
        {}],
        10 : [function(a, module) { (function(a) {
                function c(a) {
                    for (var i = 0; i < a.length; i++) {
                        var c = a[i];
                        if (c.buffer instanceof ArrayBuffer) {
                            var h = c.buffer;
                            if (c.byteLength !== h.byteLength) {
                                var y = new Uint8Array(c.byteLength);
                                y.set(new Uint8Array(h, c.byteOffset, c.byteLength)),
                                h = y.buffer
                            }
                            a[i] = h
                        }
                    }
                }
                function h(a, h) {
                    h = h || {};
                    var y = new g;
                    c(a);
                    for (var i = 0; i < a.length; i++) y.append(a[i]);
                    return h.type ? y.getBlob(h.type) : y.getBlob()
                }
                function y(a, h) {
                    return c(a),
                    new Blob(a, h || {})
                }
                var g = a.BlobBuilder || a.WebKitBlobBuilder || a.MSBlobBuilder || a.MozBlobBuilder,
                b = function() {
                    try {
                        var a = new Blob(["hi"]);
                        return 2 === a.size
                    } catch(e) {
                        return ! 1
                    }
                } (),
                v = b &&
                function() {
                    try {
                        var a = new Blob([new Uint8Array([1, 2])]);
                        return 2 === a.size
                    } catch(e) {
                        return ! 1
                    }
                } (),
                w = g && g.prototype.append && g.prototype.getBlob;
                module.exports = function() {
                    return b ? v ? a.Blob: y: w ? h: void 0
                } ()
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {}],
        11 : [function(a, module) {
            var c = [].slice;
            module.exports = function(a, h) {
                if ("string" == typeof h && (h = a[h]), "function" != typeof h) throw new Error("bind() requires a function");
                var y = c.call(arguments, 2);
                return function() {
                    return h.apply(a, y.concat(c.call(arguments)))
                }
            }
        },
        {}],
        12 : [function(a, module) {
            function c(a) {
                return a ? h(a) : void 0
            }
            function h(a) {
                for (var h in c.prototype) a[h] = c.prototype[h];
                return a
            }
            module.exports = c,
            c.prototype.on = c.prototype.addEventListener = function(a, c) {
                return this._callbacks = this._callbacks || {},
                (this._callbacks["$" + a] = this._callbacks["$" + a] || []).push(c),
                this
            },
            c.prototype.once = function(a, c) {
                function h() {
                    this.off(a, h),
                    c.apply(this, arguments)
                }
                return h.fn = c,
                this.on(a, h),
                this
            },
            c.prototype.off = c.prototype.removeListener = c.prototype.removeAllListeners = c.prototype.removeEventListener = function(a, c) {
                if (this._callbacks = this._callbacks || {},
                0 == arguments.length) return this._callbacks = {},
                this;
                var h = this._callbacks["$" + a];
                if (!h) return this;
                if (1 == arguments.length) return delete this._callbacks["$" + a],
                this;
                for (var y, i = 0; i < h.length; i++) if (y = h[i], y === c || y.fn === c) {
                    h.splice(i, 1);
                    break
                }
                return this
            },
            c.prototype.emit = function(a) {
                this._callbacks = this._callbacks || {};
                var c = [].slice.call(arguments, 1),
                h = this._callbacks["$" + a];
                if (h) {
                    h = h.slice(0);
                    for (var i = 0,
                    y = h.length; y > i; ++i) h[i].apply(this, c)
                }
                return this
            },
            c.prototype.listeners = function(a) {
                return this._callbacks = this._callbacks || {},
                this._callbacks["$" + a] || []
            },
            c.prototype.hasListeners = function(a) {
                return !! this.listeners(a).length
            }
        },
        {}],
        13 : [function(a, module) {
            module.exports = function(a, c) {
                var h = function() {};
                h.prototype = c.prototype,
                a.prototype = new h,
                a.prototype.constructor = a
            }
        },
        {}],
        14 : [function(a, module, exports) {
            function c() {
                return "WebkitAppearance" in document.documentElement.style || window.console && (console.firebug || console.exception && console.table) || navigator.userAgent.toLowerCase().match(/firefox\/(\d+)/) && parseInt(RegExp.$1, 10) >= 31
            }
            function h() {
                var a = arguments,
                c = this.useColors;
                if (a[0] = (c ? "%c": "") + this.namespace + (c ? " %c": " ") + a[0] + (c ? "%c ": " ") + "+" + exports.humanize(this.diff), !c) return a;
                var h = "color: " + this.color;
                a = [a[0], h, "color: inherit"].concat(Array.prototype.slice.call(a, 1));
                var y = 0,
                g = 0;
                return a[0].replace(/%[a-z%]/g,
                function(a) {
                    "%%" !== a && (y++, "%c" === a && (g = y))
                }),
                a.splice(g, 0, h),
                a
            }
            function y() {
                return "object" == typeof console && console.log && Function.prototype.apply.call(console.log, console, arguments)
            }
            function g(a) {
                try {
                    null == a ? exports.storage.removeItem("debug") : exports.storage.debug = a
                } catch(e) {}
            }
            function b() {
                var r;
                try {
                    r = exports.storage.debug
                } catch(e) {}
                return r
            }
            function v() {
                try {
                    return window.localStorage
                } catch(e) {}
            }
            exports = module.exports = a("./debug"),
            exports.log = y,
            exports.formatArgs = h,
            exports.save = g,
            exports.load = b,
            exports.useColors = c,
            exports.storage = "undefined" != typeof chrome && "undefined" != typeof chrome.storage ? chrome.storage.local: v(),
            exports.colors = ["lightseagreen", "forestgreen", "goldenrod", "dodgerblue", "darkorchid", "crimson"],
            exports.formatters.j = function(a) {
                return JSON.stringify(a)
            },
            exports.enable(b())
        },
        {
            "./debug": 15
        }],
        15 : [function(a, module, exports) {
            function c() {
                return exports.colors[k++%exports.colors.length]
            }
            function h(a) {
                function h() {}
                function y() {
                    var a = y,
                    h = +new Date,
                    g = h - (w || h);
                    a.diff = g,
                    a.prev = w,
                    a.curr = h,
                    w = h,
                    null == a.useColors && (a.useColors = exports.useColors()),
                    null == a.color && a.useColors && (a.color = c());
                    var b = Array.prototype.slice.call(arguments);
                    b[0] = exports.coerce(b[0]),
                    "string" != typeof b[0] && (b = ["%o"].concat(b));
                    var v = 0;
                    b[0] = b[0].replace(/%([a-z%])/g,
                    function(c, h) {
                        if ("%%" === c) return c;
                        v++;
                        var y = exports.formatters[h];
                        if ("function" == typeof y) {
                            var g = b[v];
                            c = y.call(a, g),
                            b.splice(v, 1),
                            v--
                        }
                        return c
                    }),
                    "function" == typeof exports.formatArgs && (b = exports.formatArgs.apply(a, b));
                    var k = y.log || exports.log || console.log.bind(console);
                    k.apply(a, b)
                }
                h.enabled = !1,
                y.enabled = !0;
                var g = exports.enabled(a) ? y: h;
                return g.namespace = a,
                g
            }
            function y(a) {
                exports.save(a);
                for (var c = (a || "").split(/[\s,]+/), h = c.length, i = 0; h > i; i++) c[i] && (a = c[i].replace(/\*/g, ".*?"), "-" === a[0] ? exports.skips.push(new RegExp("^" + a.substr(1) + "$")) : exports.names.push(new RegExp("^" + a + "$")))
            }
            function g() {
                exports.enable("")
            }
            function b(a) {
                var i, c;
                for (i = 0, c = exports.skips.length; c > i; i++) if (exports.skips[i].test(a)) return ! 1;
                for (i = 0, c = exports.names.length; c > i; i++) if (exports.names[i].test(a)) return ! 0;
                return ! 1
            }
            function v(a) {
                return a instanceof Error ? a.stack || a.message: a
            }
            exports = module.exports = h,
            exports.coerce = v,
            exports.disable = g,
            exports.enable = y,
            exports.enabled = b,
            exports.humanize = a("ms"),
            exports.names = [],
            exports.skips = [],
            exports.formatters = {};
            var w, k = 0
        },
        {
            ms: 36
        }],
        16 : [function(a, module) {
            module.exports = a("./lib/")
        },
        {
            "./lib/": 17
        }],
        17 : [function(a, module) {
            module.exports = a("./socket"),
            module.exports.parser = a("engine.io-parser")
        },
        {
            "./socket": 18,
            "engine.io-parser": 27
        }],
        18 : [function(a, module) { (function(c) {
                function h(a, y) {
                    if (! (this instanceof h)) return new h(a, y);
                    y = y || {},
                    a && "object" == typeof a && (y = a, a = null),
                    a ? (a = A(a), y.hostname = a.host, y.secure = "https" == a.protocol || "wss" == a.protocol, y.port = a.port, a.query && (y.query = a.query)) : y.host && (y.hostname = A(y.host).host),
                    this.secure = null != y.secure ? y.secure: c.location && "https:" == location.protocol,
                    y.hostname && !y.port && (y.port = this.secure ? "443": "80"),
                    this.agent = y.agent || !1,
                    this.hostname = y.hostname || (c.location ? location.hostname: "localhost"),
                    this.port = y.port || (c.location && location.port ? location.port: this.secure ? 443 : 80),
                    this.query = y.query || {},
                    "string" == typeof this.query && (this.query = C.decode(this.query)),
                    this.upgrade = !1 !== y.upgrade,
                    this.path = (y.path || "/engine.io").replace(/\/$/, "") + "/",
                    this.forceJSONP = !!y.forceJSONP,
                    this.jsonp = !1 !== y.jsonp,
                    this.forceBase64 = !!y.forceBase64,
                    this.enablesXDR = !!y.enablesXDR,
                    this.timestampParam = y.timestampParam || "t",
                    this.timestampRequests = y.timestampRequests,
                    this.transports = y.transports || ["polling", "websocket"],
                    this.readyState = "",
                    this.writeBuffer = [],
                    this.policyPort = y.policyPort || 843,
                    this.rememberUpgrade = y.rememberUpgrade || !1,
                    this.binaryType = null,
                    this.onlyBinaryUpgrades = y.onlyBinaryUpgrades,
                    this.perMessageDeflate = !1 !== y.perMessageDeflate ? y.perMessageDeflate || {}: !1,
                    !0 === this.perMessageDeflate && (this.perMessageDeflate = {}),
                    this.perMessageDeflate && null == this.perMessageDeflate.threshold && (this.perMessageDeflate.threshold = 1024),
                    this.pfx = y.pfx || null,
                    this.key = y.key || null,
                    this.passphrase = y.passphrase || null,
                    this.cert = y.cert || null,
                    this.ca = y.ca || null,
                    this.ciphers = y.ciphers || null,
                    this.rejectUnauthorized = void 0 === y.rejectUnauthorized ? null: y.rejectUnauthorized;
                    var g = "object" == typeof c && c;
                    g.global === g && y.extraHeaders && Object.keys(y.extraHeaders).length > 0 && (this.extraHeaders = y.extraHeaders),
                    this.open()
                }
                function y(a) {
                    var o = {};
                    for (var i in a) a.hasOwnProperty(i) && (o[i] = a[i]);
                    return o
                }
                var g = a("./transports"),
                b = a("component-emitter"),
                v = a("debug")("engine.io-client:socket"),
                w = a("indexof"),
                k = a("engine.io-parser"),
                A = a("parseuri"),
                B = a("parsejson"),
                C = a("parseqs");
                module.exports = h,
                h.priorWebsocketSuccess = !1,
                b(h.prototype),
                h.protocol = k.protocol,
                h.Socket = h,
                h.Transport = a("./transport"),
                h.transports = a("./transports"),
                h.parser = a("engine.io-parser"),
                h.prototype.createTransport = function(a) {
                    v("creating transport "%s"", a);
                    var c = y(this.query);
                    c.EIO = k.protocol,
                    c.transport = a,
                    this.id && (c.sid = this.id);
                    var h = new g[a]({
                        agent: this.agent,
                        hostname: this.hostname,
                        port: this.port,
                        secure: this.secure,
                        path: this.path,
                        query: c,
                        forceJSONP: this.forceJSONP,
                        jsonp: this.jsonp,
                        forceBase64: this.forceBase64,
                        enablesXDR: this.enablesXDR,
                        timestampRequests: this.timestampRequests,
                        timestampParam: this.timestampParam,
                        policyPort: this.policyPort,
                        socket: this,
                        pfx: this.pfx,
                        key: this.key,
                        passphrase: this.passphrase,
                        cert: this.cert,
                        ca: this.ca,
                        ciphers: this.ciphers,
                        rejectUnauthorized: this.rejectUnauthorized,
                        perMessageDeflate: this.perMessageDeflate,
                        extraHeaders: this.extraHeaders
                    });
                    return h
                },
                h.prototype.open = function() {
                    var a;
                    if (this.rememberUpgrade && h.priorWebsocketSuccess && -1 != this.transports.indexOf("websocket")) a = "websocket";
                    else {
                        if (0 === this.transports.length) {
                            var c = this;
                            return void setTimeout(function() {
                                c.emit("error", "No transports available")
                            },
                            0)
                        }
                        a = this.transports[0]
                    }
                    this.readyState = "opening";
                    try {
                        a = this.createTransport(a)
                    } catch(e) {
                        return this.transports.shift(),
                        void this.open()
                    }
                    a.open(),
                    this.setTransport(a)
                },
                h.prototype.setTransport = function(a) {
                    v("setting transport %s", a.name);
                    var c = this;
                    this.transport && (v("clearing existing transport %s", this.transport.name), this.transport.removeAllListeners()),
                    this.transport = a,
                    a.on("drain",
                    function() {
                        c.onDrain()
                    }).on("packet",
                    function(a) {
                        c.onPacket(a)
                    }).on("error",
                    function(e) {
                        c.onError(e)
                    }).on("close",
                    function() {
                        c.onClose("transport close")
                    })
                },
                h.prototype.probe = function(a) {
                    function c() {
                        if (S.onlyBinaryUpgrades) {
                            var c = !this.supportsBinary && S.transport.supportsBinary;
                            C = C || c
                        }
                        C || (v("probe transport "%s" opened", a), B.send([{
                            type: "ping",
                            data: "probe"
                        }]), B.once("packet",
                        function(c) {
                            if (!C) if ("pong" == c.type && "probe" == c.data) {
                                if (v("probe transport "%s" pong", a), S.upgrading = !0, S.emit("upgrading", B), !B) return;
                                h.priorWebsocketSuccess = "websocket" == B.name,
                                v("pausing current transport "%s"", S.transport.name),
                                S.transport.pause(function() {
                                    C || "closed" != S.readyState && (v("changing transport and sending upgrade packet"), A(), S.setTransport(B), B.send([{
                                        type: "upgrade"
                                    }]), S.emit("upgrade", B), B = null, S.upgrading = !1, S.flush())
                                })
                            } else {
                                v("probe transport "%s" failed", a);
                                var y = new Error("probe error");
                                y.transport = B.name,
                                S.emit("upgradeError", y)
                            }
                        }))
                    }
                    function y() {
                        C || (C = !0, A(), B.close(), B = null)
                    }
                    function g(c) {
                        var h = new Error("probe error: " + c);
                        h.transport = B.name,
                        y(),
                        v("probe transport "%s" failed because of error: %s", a, c),
                        S.emit("upgradeError", h)
                    }
                    function b() {
                        g("transport closed")
                    }
                    function w() {
                        g("socket closed")
                    }
                    function k(a) {
                        B && a.name != B.name && (v(""%s" works - aborting "%s"", a.name, B.name), y())
                    }
                    function A() {
                        B.removeListener("open", c),
                        B.removeListener("error", g),
                        B.removeListener("close", b),
                        S.removeListener("close", w),
                        S.removeListener("upgrading", k)
                    }
                    v("probing transport "%s"", a);
                    var B = this.createTransport(a, {
                        probe: 1
                    }),
                    C = !1,
                    S = this;
                    h.priorWebsocketSuccess = !1,
                    B.once("open", c),
                    B.once("error", g),
                    B.once("close", b),
                    this.once("close", w),
                    this.once("upgrading", k),
                    B.open()
                },
                h.prototype.onOpen = function() {
                    if (v("socket open"), this.readyState = "open", h.priorWebsocketSuccess = "websocket" == this.transport.name, this.emit("open"), this.flush(), "open" == this.readyState && this.upgrade && this.transport.pause) {
                        v("starting upgrade probes");
                        for (var i = 0,
                        l = this.upgrades.length; l > i; i++) this.probe(this.upgrades[i])
                    }
                },
                h.prototype.onPacket = function(a) {
                    if ("opening" == this.readyState || "open" == this.readyState) switch (v("socket receive: type "%s", data "%s"", a.type, a.data), this.emit("packet", a), this.emit("heartbeat"), a.type) {
                    case "open":
                        this.onHandshake(B(a.data));
                        break;
                    case "pong":
                        this.setPing(),
                        this.emit("pong");
                        break;
                    case "error":
                        var c = new Error("server error");
                        c.code = a.data,
                        this.onError(c);
                        break;
                    case "message":
                        this.emit("data", a.data),
                        this.emit("message", a.data)
                    } else v("packet received with socket readyState "%s"", this.readyState)
                },
                h.prototype.onHandshake = function(a) {
                    this.emit("handshake", a),
                    this.id = a.sid,
                    this.transport.query.sid = a.sid,
                    this.upgrades = this.filterUpgrades(a.upgrades),
                    this.pingInterval = a.pingInterval,
                    this.pingTimeout = a.pingTimeout,
                    this.onOpen(),
                    "closed" != this.readyState && (this.setPing(), this.removeListener("heartbeat", this.onHeartbeat), this.on("heartbeat", this.onHeartbeat))
                },
                h.prototype.onHeartbeat = function(a) {
                    clearTimeout(this.pingTimeoutTimer);
                    var c = this;
                    c.pingTimeoutTimer = setTimeout(function() {
                        "closed" != c.readyState && c.onClose("ping timeout")
                    },
                    a || c.pingInterval + c.pingTimeout)
                },
                h.prototype.setPing = function() {
                    var a = this;
                    clearTimeout(a.pingIntervalTimer),
                    a.pingIntervalTimer = setTimeout(function() {
                        v("writing ping packet - expecting pong within %sms", a.pingTimeout),
                        a.ping(),
                        a.onHeartbeat(a.pingTimeout)
                    },
                    a.pingInterval)
                },
                h.prototype.ping = function() {
                    var a = this;
                    this.sendPacket("ping",
                    function() {
                        a.emit("ping")
                    })
                },
                h.prototype.onDrain = function() {
                    this.writeBuffer.splice(0, this.prevBufferLen),
                    this.prevBufferLen = 0,
                    0 === this.writeBuffer.length ? this.emit("drain") : this.flush()
                },
                h.prototype.flush = function() {
                    "closed" != this.readyState && this.transport.writable && !this.upgrading && this.writeBuffer.length && (v("flushing %d packets in socket", this.writeBuffer.length), this.transport.send(this.writeBuffer), this.prevBufferLen = this.writeBuffer.length, this.emit("flush"))
                },
                h.prototype.write = h.prototype.send = function(a, c, h) {
                    return this.sendPacket("message", a, c, h),
                    this
                },
                h.prototype.sendPacket = function(a, c, h, y) {
                    if ("function" == typeof c && (y = c, c = void 0), "function" == typeof h && (y = h, h = null), "closing" != this.readyState && "closed" != this.readyState) {
                        h = h || {},
                        h.compress = !1 !== h.compress;
                        var g = {
                            type: a,
                            data: c,
                            options: h
                        };
                        this.emit("packetCreate", g),
                        this.writeBuffer.push(g),
                        y && this.once("flush", y),
                        this.flush()
                    }
                },
                h.prototype.close = function() {
                    function a() {
                        y.onClose("forced close"),
                        v("socket closing - telling transport to close"),
                        y.transport.close()
                    }
                    function c() {
                        y.removeListener("upgrade", c),
                        y.removeListener("upgradeError", c),
                        a()
                    }
                    function h() {
                        y.once("upgrade", c),
                        y.once("upgradeError", c)
                    }
                    if ("opening" == this.readyState || "open" == this.readyState) {
                        this.readyState = "closing";
                        var y = this;
                        this.writeBuffer.length ? this.once("drain",
                        function() {
                            this.upgrading ? h() : a()
                        }) : this.upgrading ? h() : a()
                    }
                    return this
                },
                h.prototype.onError = function(a) {
                    v("socket error %j", a),
                    h.priorWebsocketSuccess = !1,
                    this.emit("error", a),
                    this.onClose("transport error", a)
                },
                h.prototype.onClose = function(a, c) {
                    if ("opening" == this.readyState || "open" == this.readyState || "closing" == this.readyState) {
                        v("socket close with reason: "%s"", a);
                        var h = this;
                        clearTimeout(this.pingIntervalTimer),
                        clearTimeout(this.pingTimeoutTimer),
                        this.transport.removeAllListeners("close"),
                        this.transport.close(),
                        this.transport.removeAllListeners(),
                        this.readyState = "closed",
                        this.id = null,
                        this.emit("close", a, c),
                        h.writeBuffer = [],
                        h.prevBufferLen = 0
                    }
                },
                h.prototype.filterUpgrades = function(a) {
                    for (var c = [], i = 0, h = a.length; h > i; i++)~w(this.transports, a[i]) && c.push(a[i]);
                    return c
                }
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            "./transport": 19,
            "./transports": 20,
            "component-emitter": 26,
            debug: 14,
            "engine.io-parser": 27,
            indexof: 33,
            parsejson: 37,
            parseqs: 38,
            parseuri: 39
        }],
        19 : [function(a, module) {
            function c(a) {
                this.path = a.path,
                this.hostname = a.hostname,
                this.port = a.port,
                this.secure = a.secure,
                this.query = a.query,
                this.timestampParam = a.timestampParam,
                this.timestampRequests = a.timestampRequests,
                this.readyState = "",
                this.agent = a.agent || !1,
                this.socket = a.socket,
                this.enablesXDR = a.enablesXDR,
                this.pfx = a.pfx,
                this.key = a.key,
                this.passphrase = a.passphrase,
                this.cert = a.cert,
                this.ca = a.ca,
                this.ciphers = a.ciphers,
                this.rejectUnauthorized = a.rejectUnauthorized,
                this.extraHeaders = a.extraHeaders
            }
            var h = a("engine.io-parser"),
            y = a("component-emitter");
            module.exports = c,
            y(c.prototype),
            c.prototype.onError = function(a, c) {
                var h = new Error(a);
                return h.type = "TransportError",
                h.description = c,
                this.emit("error", h),
                this
            },
            c.prototype.open = function() {
                return ("closed" == this.readyState || "" == this.readyState) && (this.readyState = "opening", this.doOpen()),
                this
            },
            c.prototype.close = function() {
                return ("opening" == this.readyState || "open" == this.readyState) && (this.doClose(), this.onClose()),
                this
            },
            c.prototype.send = function(a) {
                if ("open" != this.readyState) throw new Error("Transport not open");
                this.write(a)
            },
            c.prototype.onOpen = function() {
                this.readyState = "open",
                this.writable = !0,
                this.emit("open")
            },
            c.prototype.onData = function(a) {
                var c = h.decodePacket(a, this.socket.binaryType);
                this.onPacket(c)
            },
            c.prototype.onPacket = function(a) {
                this.emit("packet", a)
            },
            c.prototype.onClose = function() {
                this.readyState = "closed",
                this.emit("close")
            }
        },
        {
            "component-emitter": 26,
            "engine.io-parser": 27
        }],
        20 : [function(a, module, exports) { (function(c) {
                function h(a) {
                    var h, v = !1,
                    w = !1,
                    k = !1 !== a.jsonp;
                    if (c.location) {
                        var A = "https:" == location.protocol,
                        port = location.port;
                        port || (port = A ? 443 : 80),
                        v = a.hostname != location.hostname || port != a.port,
                        w = a.secure != A
                    }
                    if (a.xdomain = v, a.xscheme = w, h = new y(a), "open" in h && !a.forceJSONP) return new g(a);
                    if (!k) throw new Error("JSONP disabled");
                    return new b(a)
                }
                var y = a("xmlhttprequest-ssl"),
                g = a("./polling-xhr"),
                b = a("./polling-jsonp"),
                v = a("./websocket");
                exports.polling = h,
                exports.websocket = v
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            "./polling-jsonp": 21,
            "./polling-xhr": 22,
            "./websocket": 24,
            "xmlhttprequest-ssl": 25
        }],
        21 : [function(a, module) { (function(c) {
                function h() {}
                function y(a) {
                    g.call(this, a),
                    this.query = this.query || {},
                    v || (c.___eio || (c.___eio = []), v = c.___eio),
                    this.index = v.length;
                    var y = this;
                    v.push(function(a) {
                        y.onData(a)
                    }),
                    this.query.j = this.index,
                    c.document && c.addEventListener && c.addEventListener("beforeunload",
                    function() {
                        y.script && (y.script.onerror = h)
                    },
                    !1)
                }
                var g = a("./polling"),
                b = a("component-inherit");
                module.exports = y;
                var v, w = /\n/g,
                k = /\\n/g;
                b(y, g),
                y.prototype.supportsBinary = !1,
                y.prototype.doClose = function() {
                    this.script && (this.script.parentNode.removeChild(this.script), this.script = null),
                    this.form && (this.form.parentNode.removeChild(this.form), this.form = null, this.iframe = null),
                    g.prototype.doClose.call(this)
                },
                y.prototype.doPoll = function() {
                    var a = this,
                    c = document.createElement("script");
                    this.script && (this.script.parentNode.removeChild(this.script), this.script = null),
                    c.async = !0,
                    c.src = this.uri(),
                    c.onerror = function(e) {
                        a.onError("jsonp poll error", e)
                    };
                    var h = document.getElementsByTagName("script")[0];
                    h.parentNode.insertBefore(c, h),
                    this.script = c;
                    var y = "undefined" != typeof navigator && /gecko/i.test(navigator.userAgent);
                    y && setTimeout(function() {
                        var a = document.createElement("iframe");
                        document.body.appendChild(a),
                        document.body.removeChild(a)
                    },
                    100)
                },
                y.prototype.doWrite = function(a, c) {
                    function h() {
                        y(),
                        c()
                    }
                    function y() {
                        if (g.iframe) try {
                            g.form.removeChild(g.iframe)
                        } catch(e) {
                            g.onError("jsonp polling iframe removal error", e)
                        }
                        try {
                            var a = "<iframe src="javascript:0" name="" + g.iframeId + "">";
                            b = document.createElement(a)
                        } catch(e) {
                            b = document.createElement("iframe"),
                            b.name = g.iframeId,
                            b.src = "javascript:0"
                        }
                        b.id = g.iframeId,
                        g.form.appendChild(b),
                        g.iframe = b
                    }
                    var g = this;
                    if (!this.form) {
                        var b, v = document.createElement("form"),
                        A = document.createElement("textarea"),
                        B = this.iframeId = "eio_iframe_" + this.index;
                        v.className = "socketio",
                        v.style.position = "absolute",
                        v.style.top = "-1000px",
                        v.style.left = "-1000px",
                        v.target = B,
                        v.method = "POST",
                        v.setAttribute("accept-charset", "utf-8"),
                        A.name = "d",
                        v.appendChild(A),
                        document.body.appendChild(v),
                        this.form = v,
                        this.area = A
                    }
                    this.form.action = this.uri(),
                    y(),
                    a = a.replace(k, "\\\n"),
                    this.area.value = a.replace(w, "\\n");
                    try {
                        this.form.submit()
                    } catch(e) {}
                    this.iframe.attachEvent ? this.iframe.onreadystatechange = function() {
                        "complete" == g.iframe.readyState && h()
                    }: this.iframe.onload = h
                }
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            "./polling": 23,
            "component-inherit": 13
        }],
        22 : [function(a, module) { (function(c) {
                function h() {}
                function y(a) {
                    if (w.call(this, a), c.location) {
                        var h = "https:" == location.protocol,
                        port = location.port;
                        port || (port = h ? 443 : 80),
                        this.xd = a.hostname != c.location.hostname || port != a.port,
                        this.xs = a.secure != h
                    } else this.extraHeaders = a.extraHeaders
                }
                function g(a) {
                    this.method = a.method || "GET",
                    this.uri = a.uri,
                    this.xd = !!a.xd,
                    this.xs = !!a.xs,
                    this.async = !1 !== a.async,
                    this.data = void 0 != a.data ? a.data: null,
                    this.agent = a.agent,
                    this.isBinary = a.isBinary,
                    this.supportsBinary = a.supportsBinary,
                    this.enablesXDR = a.enablesXDR,
                    this.pfx = a.pfx,
                    this.key = a.key,
                    this.passphrase = a.passphrase,
                    this.cert = a.cert,
                    this.ca = a.ca,
                    this.ciphers = a.ciphers,
                    this.rejectUnauthorized = a.rejectUnauthorized,
                    this.extraHeaders = a.extraHeaders,
                    this.create()
                }
                function b() {
                    for (var i in g.requests) g.requests.hasOwnProperty(i) && g.requests[i].abort()
                }
                var v = a("xmlhttprequest-ssl"),
                w = a("./polling"),
                k = a("component-emitter"),
                A = a("component-inherit"),
                B = a("debug")("engine.io-client:polling-xhr");
                module.exports = y,
                module.exports.Request = g,
                A(y, w),
                y.prototype.supportsBinary = !0,
                y.prototype.request = function(a) {
                    return a = a || {},
                    a.uri = this.uri(),
                    a.xd = this.xd,
                    a.xs = this.xs,
                    a.agent = this.agent || !1,
                    a.supportsBinary = this.supportsBinary,
                    a.enablesXDR = this.enablesXDR,
                    a.pfx = this.pfx,
                    a.key = this.key,
                    a.passphrase = this.passphrase,
                    a.cert = this.cert,
                    a.ca = this.ca,
                    a.ciphers = this.ciphers,
                    a.rejectUnauthorized = this.rejectUnauthorized,
                    a.extraHeaders = this.extraHeaders,
                    new g(a)
                },
                y.prototype.doWrite = function(a, c) {
                    var h = "string" != typeof a && void 0 !== a,
                    req = this.request({
                        method: "POST",
                        data: a,
                        isBinary: h
                    }),
                    y = this;
                    req.on("success", c),
                    req.on("error",
                    function(a) {
                        y.onError("xhr post error", a)
                    }),
                    this.sendXhr = req
                },
                y.prototype.doPoll = function() {
                    B("xhr poll");
                    var req = this.request(),
                    a = this;
                    req.on("data",
                    function(c) {
                        a.onData(c)
                    }),
                    req.on("error",
                    function(c) {
                        a.onError("xhr poll error", c)
                    }),
                    this.pollXhr = req
                },
                k(g.prototype),
                g.prototype.create = function() {
                    var a = {
                        agent: this.agent,
                        xdomain: this.xd,
                        xscheme: this.xs,
                        enablesXDR: this.enablesXDR
                    };
                    a.pfx = this.pfx,
                    a.key = this.key,
                    a.passphrase = this.passphrase,
                    a.cert = this.cert,
                    a.ca = this.ca,
                    a.ciphers = this.ciphers,
                    a.rejectUnauthorized = this.rejectUnauthorized;
                    var h = this.xhr = new v(a),
                    y = this;
                    try {
                        B("xhr open %s: %s", this.method, this.uri),
                        h.open(this.method, this.uri, this.async);
                        try {
                            if (this.extraHeaders) {
                                h.setDisableHeaderCheck(!0);
                                for (var i in this.extraHeaders) this.extraHeaders.hasOwnProperty(i) && h.setRequestHeader(i, this.extraHeaders[i])
                            }
                        } catch(e) {}
                        if (this.supportsBinary && (h.responseType = "arraybuffer"), "POST" == this.method) try {
                            this.isBinary ? h.setRequestHeader("Content-type", "application/octet-stream") : h.setRequestHeader("Content-type", "text/plain;charset=UTF-8")
                        } catch(e) {}
                        "withCredentials" in h && (h.withCredentials = !0),
                        this.hasXDR() ? (h.onload = function() {
                            y.onLoad()
                        },
                        h.onerror = function() {
                            y.onError(h.responseText)
                        }) : h.onreadystatechange = function() {
                            4 == h.readyState && (200 == h.status || 1223 == h.status ? y.onLoad() : setTimeout(function() {
                                y.onError(h.status)
                            },
                            0))
                        },
                        B("xhr data %s", this.data),
                        h.send(this.data)
                    } catch(e) {
                        return void setTimeout(function() {
                            y.onError(e)
                        },
                        0)
                    }
                    c.document && (this.index = g.requestsCount++, g.requests[this.index] = this)
                },
                g.prototype.onSuccess = function() {
                    this.emit("success"),
                    this.cleanup()
                },
                g.prototype.onData = function(a) {
                    this.emit("data", a),
                    this.onSuccess()
                },
                g.prototype.onError = function(a) {
                    this.emit("error", a),
                    this.cleanup(!0)
                },
                g.prototype.cleanup = function(a) {
                    if ("undefined" != typeof this.xhr && null !== this.xhr) {
                        if (this.hasXDR() ? this.xhr.onload = this.xhr.onerror = h: this.xhr.onreadystatechange = h, a) try {
                            this.xhr.abort()
                        } catch(e) {}
                        c.document && delete g.requests[this.index],
                        this.xhr = null
                    }
                },
                g.prototype.onLoad = function() {
                    var a;
                    try {
                        var c;
                        try {
                            c = this.xhr.getResponseHeader("Content-Type").split(";")[0]
                        } catch(e) {}
                        if ("application/octet-stream" === c) a = this.xhr.response;
                        else if (this.supportsBinary) try {
                            a = String.fromCharCode.apply(null, new Uint8Array(this.xhr.response))
                        } catch(e) {
                            for (var h = new Uint8Array(this.xhr.response), y = [], g = 0, b = h.length; b > g; g++) y.push(h[g]);
                            a = String.fromCharCode.apply(null, y)
                        } else a = this.xhr.responseText
                    } catch(e) {
                        this.onError(e)
                    }
                    null != a && this.onData(a)
                },
                g.prototype.hasXDR = function() {
                    return "undefined" != typeof c.XDomainRequest && !this.xs && this.enablesXDR
                },
                g.prototype.abort = function() {
                    this.cleanup()
                },
                c.document && (g.requestsCount = 0, g.requests = {},
                c.attachEvent ? c.attachEvent("onunload", b) : c.addEventListener && c.addEventListener("beforeunload", b, !1))
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            "./polling": 23,
            "component-emitter": 26,
            "component-inherit": 13,
            debug: 14,
            "xmlhttprequest-ssl": 25
        }],
        23 : [function(a, module) {
            function c(a) {
                var c = a && a.forceBase64; (!k || c) && (this.supportsBinary = !1),
                h.call(this, a)
            }
            var h = a("../transport"),
            y = a("parseqs"),
            g = a("engine.io-parser"),
            b = a("component-inherit"),
            v = a("yeast"),
            w = a("debug")("engine.io-client:polling");
            module.exports = c;
            var k = function() {
                var c = a("xmlhttprequest-ssl"),
                h = new c({
                    xdomain: !1
                });
                return null != h.responseType
            } ();
            b(c, h),
            c.prototype.name = "polling",
            c.prototype.doOpen = function() {
                this.poll()
            },
            c.prototype.pause = function(a) {
                function c() {
                    w("paused"),
                    h.readyState = "paused",
                    a()
                }
                var h = this;
                if (this.readyState = "pausing", this.polling || !this.writable) {
                    var y = 0;
                    this.polling && (w("we are currently polling - waiting to pause"), y++, this.once("pollComplete",
                    function() {
                        w("pre-pause polling complete"),
                        --y || c()
                    })),
                    this.writable || (w("we are currently writing - waiting to pause"), y++, this.once("drain",
                    function() {
                        w("pre-pause writing complete"),
                        --y || c()
                    }))
                } else c()
            },
            c.prototype.poll = function() {
                w("polling"),
                this.polling = !0,
                this.doPoll(),
                this.emit("poll")
            },
            c.prototype.onData = function(a) {
                var c = this;
                w("polling got data %s", a);
                var h = function(a) {
                    return "opening" == c.readyState && c.onOpen(),
                    "close" == a.type ? (c.onClose(), !1) : void c.onPacket(a)
                };
                g.decodePayload(a, this.socket.binaryType, h),
                "closed" != this.readyState && (this.polling = !1, this.emit("pollComplete"), "open" == this.readyState ? this.poll() : w("ignoring poll - transport state "%s"", this.readyState))
            },
            c.prototype.doClose = function() {
                function a() {
                    w("writing close packet"),
                    c.write([{
                        type: "close"
                    }])
                }
                var c = this;
                "open" == this.readyState ? (w("transport open - closing"), a()) : (w("transport not open - deferring close"), this.once("open", a))
            },
            c.prototype.write = function(a) {
                var c = this;
                this.writable = !1;
                var h = function() {
                    c.writable = !0,
                    c.emit("drain")
                },
                c = this;
                g.encodePayload(a, this.supportsBinary,
                function(a) {
                    c.doWrite(a, h)
                })
            },
            c.prototype.uri = function() {
                var a = this.query || {},
                c = this.secure ? "https": "http",
                port = ""; ! 1 !== this.timestampRequests && (a[this.timestampParam] = v()),
                this.supportsBinary || a.sid || (a.b64 = 1),
                a = y.encode(a),
                this.port && ("https" == c && 443 != this.port || "http" == c && 80 != this.port) && (port = ":" + this.port),
                a.length && (a = "?" + a);
                var h = -1 !== this.hostname.indexOf(":");
                return c + "://" + (h ? "[" + this.hostname + "]": this.hostname) + port + this.path + a
            }
        },
        {
            "../transport": 19,
            "component-inherit": 13,
            debug: 14,
            "engine.io-parser": 27,
            parseqs: 38,
            "xmlhttprequest-ssl": 25,
            yeast: 46
        }],
        24 : [function(a, module) { (function(c) {
                function h(a) {
                    var c = a && a.forceBase64;
                    c && (this.supportsBinary = !1),
                    this.perMessageDeflate = a.perMessageDeflate,
                    y.call(this, a)
                }
                var y = a("../transport"),
                g = a("engine.io-parser"),
                b = a("parseqs"),
                v = a("component-inherit"),
                w = a("yeast"),
                k = a("debug")("engine.io-client:websocket"),
                A = c.WebSocket || c.MozWebSocket,
                B = A || ("undefined" != typeof window ? null: a("ws"));
                module.exports = h,
                v(h, y),
                h.prototype.name = "websocket",
                h.prototype.supportsBinary = !0,
                h.prototype.doOpen = function() {
                    if (this.check()) {
                        var a = this.uri(),
                        c = void 0,
                        h = {
                            agent: this.agent,
                            perMessageDeflate: this.perMessageDeflate
                        };
                        h.pfx = this.pfx,
                        h.key = this.key,
                        h.passphrase = this.passphrase,
                        h.cert = this.cert,
                        h.ca = this.ca,
                        h.ciphers = this.ciphers,
                        h.rejectUnauthorized = this.rejectUnauthorized,
                        this.extraHeaders && (h.headers = this.extraHeaders),
                        this.ws = A ? new B(a) : new B(a, c, h),
                        void 0 === this.ws.binaryType && (this.supportsBinary = !1),
                        this.ws.supports && this.ws.supports.binary ? (this.supportsBinary = !0, this.ws.binaryType = "buffer") : this.ws.binaryType = "arraybuffer",
                        this.addEventListeners()
                    }
                },
                h.prototype.addEventListeners = function() {
                    var a = this;
                    this.ws.onopen = function() {
                        a.onOpen()
                    },
                    this.ws.onclose = function() {
                        a.onClose()
                    },
                    this.ws.onmessage = function(c) {
                        a.onData(c.data)
                    },
                    this.ws.onerror = function(e) {
                        a.onError("websocket error", e)
                    }
                },
                "undefined" != typeof navigator && /iPad|iPhone|iPod/i.test(navigator.userAgent) && (h.prototype.onData = function(a) {
                    var c = this;
                    setTimeout(function() {
                        y.prototype.onData.call(c, a)
                    },
                    0)
                }),
                h.prototype.write = function(a) {
                    function h() {
                        y.emit("flush"),
                        setTimeout(function() {
                            y.writable = !0,
                            y.emit("drain")
                        },
                        0)
                    }
                    var y = this;
                    this.writable = !1;
                    for (var b = a.length,
                    i = 0,
                    l = b; l > i; i++) !
                    function(a) {
                        g.encodePacket(a, y.supportsBinary,
                        function(g) {
                            if (!A) {
                                var v = {};
                                if (a.options && (v.compress = a.options.compress), y.perMessageDeflate) {
                                    var w = "string" == typeof g ? c.Buffer.byteLength(g) : g.length;
                                    w < y.perMessageDeflate.threshold && (v.compress = !1)
                                }
                            }
                            try {
                                A ? y.ws.send(g) : y.ws.send(g, v)
                            } catch(e) {
                                k("websocket closed before onclose event")
                            }--b || h()
                        })
                    } (a[i])
                },
                h.prototype.onClose = function() {
                    y.prototype.onClose.call(this)
                },
                h.prototype.doClose = function() {
                    "undefined" != typeof this.ws && this.ws.close()
                },
                h.prototype.uri = function() {
                    var a = this.query || {},
                    c = this.secure ? "wss": "ws",
                    port = "";
                    this.port && ("wss" == c && 443 != this.port || "ws" == c && 80 != this.port) && (port = ":" + this.port),
                    this.timestampRequests && (a[this.timestampParam] = w()),
                    this.supportsBinary || (a.b64 = 1),
                    a = b.encode(a),
                    a.length && (a = "?" + a);
                    var h = -1 !== this.hostname.indexOf(":");
                    return c + "://" + (h ? "[" + this.hostname + "]": this.hostname) + port + this.path + a
                },
                h.prototype.check = function() {
                    return ! (!B || "__initialize" in B && this.name === h.prototype.name)
                }
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            "../transport": 19,
            "component-inherit": 13,
            debug: 14,
            "engine.io-parser": 27,
            parseqs: 38,
            ws: void 0,
            yeast: 46
        }],
        25 : [function(a, module) {
            var c = a("has-cors");
            module.exports = function(a) {
                var h = a.xdomain,
                y = a.xscheme,
                g = a.enablesXDR;
                try {
                    if ("undefined" != typeof XMLHttpRequest && (!h || c)) return new XMLHttpRequest
                } catch(e) {}
                try {
                    if ("undefined" != typeof XDomainRequest && !y && g) return new XDomainRequest
                } catch(e) {}
                if (!h) try {
                    return new ActiveXObject("Microsoft.XMLHTTP")
                } catch(e) {}
            }
        },
        {
            "has-cors": 32
        }],
        26 : [function(a, module) {
            function c(a) {
                return a ? h(a) : void 0
            }
            function h(a) {
                for (var h in c.prototype) a[h] = c.prototype[h];
                return a
            }
            module.exports = c,
            c.prototype.on = c.prototype.addEventListener = function(a, c) {
                return this._callbacks = this._callbacks || {},
                (this._callbacks[a] = this._callbacks[a] || []).push(c),
                this
            },
            c.prototype.once = function(a, c) {
                function h() {
                    y.off(a, h),
                    c.apply(this, arguments)
                }
                var y = this;
                return this._callbacks = this._callbacks || {},
                h.fn = c,
                this.on(a, h),
                this
            },
            c.prototype.off = c.prototype.removeListener = c.prototype.removeAllListeners = c.prototype.removeEventListener = function(a, c) {
                if (this._callbacks = this._callbacks || {},
                0 == arguments.length) return this._callbacks = {},
                this;
                var h = this._callbacks[a];
                if (!h) return this;
                if (1 == arguments.length) return delete this._callbacks[a],
                this;
                for (var y, i = 0; i < h.length; i++) if (y = h[i], y === c || y.fn === c) {
                    h.splice(i, 1);
                    break
                }
                return this
            },
            c.prototype.emit = function(a) {
                this._callbacks = this._callbacks || {};
                var c = [].slice.call(arguments, 1),
                h = this._callbacks[a];
                if (h) {
                    h = h.slice(0);
                    for (var i = 0,
                    y = h.length; y > i; ++i) h[i].apply(this, c)
                }
                return this
            },
            c.prototype.listeners = function(a) {
                return this._callbacks = this._callbacks || {},
                this._callbacks[a] || []
            },
            c.prototype.hasListeners = function(a) {
                return !! this.listeners(a).length
            }
        },
        {}],
        27 : [function(a, module, exports) { (function(c) {
                function h(a, c) {
                    var h = "b" + exports.packets[a.type] + a.data.data;
                    return c(h)
                }
                function y(a, c, h) {
                    if (!c) return exports.encodeBase64Packet(a, h);
                    var y = a.data,
                    g = new Uint8Array(y),
                    b = new Uint8Array(1 + y.byteLength);
                    b[0] = j[a.type];
                    for (var i = 0; i < g.length; i++) b[i + 1] = g[i];
                    return h(b.buffer)
                }
                function g(a, c, h) {
                    if (!c) return exports.encodeBase64Packet(a, h);
                    var y = new FileReader;
                    return y.onload = function() {
                        a.data = y.result,
                        exports.encodePacket(a, c, !0, h)
                    },
                    y.readAsArrayBuffer(a.data)
                }
                function b(a, c, h) {
                    if (!c) return exports.encodeBase64Packet(a, h);
                    if (T) return g(a, c, h);
                    var y = new Uint8Array(1);
                    y[0] = j[a.type];
                    var b = new N([y.buffer, a.data]);
                    return h(b)
                }
                function v(a, c, h) {
                    for (var y = new Array(a.length), g = C(a.length, h), b = function(i, a, h) {
                        c(a,
                        function(a, c) {
                            y[i] = c,
                            h(a, y)
                        })
                    },
                    i = 0; i < a.length; i++) b(i, a[i], g)
                }
                var w = a("./keys"),
                k = a("has-binary"),
                A = a("arraybuffer.slice"),
                B = a("base64-arraybuffer"),
                C = a("after"),
                S = a("utf8"),
                E = navigator.userAgent.match(/Android/i),
                _ = /PhantomJS/i.test(navigator.userAgent),
                T = E || _;
                exports.protocol = 3;
                var j = exports.packets = {
                    open: 0,
                    close: 1,
                    ping: 2,
                    pong: 3,
                    message: 4,
                    upgrade: 5,
                    noop: 6
                },
                O = w(j),
                P = {
                    type: "error",
                    data: "parser error"
                },
                N = a("blob");
                exports.encodePacket = function(a, g, v, w) {
                    "function" == typeof g && (w = g, g = !1),
                    "function" == typeof v && (w = v, v = null);
                    var k = void 0 === a.data ? void 0 : a.data.buffer || a.data;
                    if (c.ArrayBuffer && k instanceof ArrayBuffer) return y(a, g, w);
                    if (N && k instanceof c.Blob) return b(a, g, w);
                    if (k && k.base64) return h(a, w);
                    var A = j[a.type];
                    return void 0 !== a.data && (A += v ? S.encode(String(a.data)) : String(a.data)),
                    w("" + A)
                },
                exports.encodeBase64Packet = function(a, h) {
                    var y = "b" + exports.packets[a.type];
                    if (N && a.data instanceof c.Blob) {
                        var g = new FileReader;
                        return g.onload = function() {
                            var a = g.result.split(",")[1];
                            h(y + a)
                        },
                        g.readAsDataURL(a.data)
                    }
                    var b;
                    try {
                        b = String.fromCharCode.apply(null, new Uint8Array(a.data))
                    } catch(e) {
                        for (var v = new Uint8Array(a.data), w = new Array(v.length), i = 0; i < v.length; i++) w[i] = v[i];
                        b = String.fromCharCode.apply(null, w)
                    }
                    return y += c.btoa(b),
                    h(y)
                },
                exports.decodePacket = function(a, c, h) {
                    if ("string" == typeof a || void 0 === a) {
                        if ("b" == a.charAt(0)) return exports.decodeBase64Packet(a.substr(1), c);
                        if (h) try {
                            a = S.decode(a)
                        } catch(e) {
                            return P
                        }
                        var y = a.charAt(0);
                        return Number(y) == y && O[y] ? a.length > 1 ? {
                            type: O[y],
                            data: a.substring(1)
                        }: {
                            type: O[y]
                        }: P
                    }
                    var g = new Uint8Array(a),
                    y = g[0],
                    b = A(a, 1);
                    return N && "blob" === c && (b = new N([b])),
                    {
                        type: O[y],
                        data: b
                    }
                },
                exports.decodeBase64Packet = function(a, h) {
                    var y = O[a.charAt(0)];
                    if (!c.ArrayBuffer) return {
                        type: y,
                        data: {
                            base64: !0,
                            data: a.substr(1)
                        }
                    };
                    var g = B.decode(a.substr(1));
                    return "blob" === h && N && (g = new N([g])),
                    {
                        type: y,
                        data: g
                    }
                },
                exports.encodePayload = function(a, c, h) {
                    function y(a) {
                        return a.length + ":" + a
                    }
                    function g(a, h) {
                        exports.encodePacket(a, b ? c: !1, !0,
                        function(a) {
                            h(null, y(a))
                        })
                    }
                    "function" == typeof c && (h = c, c = null);
                    var b = k(a);
                    return c && b ? N && !T ? exports.encodePayloadAsBlob(a, h) : exports.encodePayloadAsArrayBuffer(a, h) : a.length ? void v(a, g,
                    function(a, c) {
                        return h(c.join(""))
                    }) : h("0:")
                },
                exports.decodePayload = function(a, c, h) {
                    if ("string" != typeof a) return exports.decodePayloadAsBinary(a, c, h);
                    "function" == typeof c && (h = c, c = null);
                    var y;
                    if ("" == a) return h(P, 0, 1);
                    for (var n, g, b = "",
                    i = 0,
                    l = a.length; l > i; i++) {
                        var v = a.charAt(i);
                        if (":" != v) b += v;
                        else {
                            if ("" == b || b != (n = Number(b))) return h(P, 0, 1);
                            if (g = a.substr(i + 1, n), b != g.length) return h(P, 0, 1);
                            if (g.length) {
                                if (y = exports.decodePacket(g, c, !0), P.type == y.type && P.data == y.data) return h(P, 0, 1);
                                var w = h(y, i + n, l);
                                if (!1 === w) return
                            }
                            i += n,
                            b = ""
                        }
                    }
                    return "" != b ? h(P, 0, 1) : void 0
                },
                exports.encodePayloadAsArrayBuffer = function(a, c) {
                    function h(a, c) {
                        exports.encodePacket(a, !0, !0,
                        function(a) {
                            return c(null, a)
                        })
                    }
                    return a.length ? void v(a, h,
                    function(a, h) {
                        var y = h.reduce(function(a, p) {
                            var c;
                            return c = "string" == typeof p ? p.length: p.byteLength,
                            a + c.toString().length + c + 2
                        },
                        0),
                        g = new Uint8Array(y),
                        b = 0;
                        return h.forEach(function(p) {
                            var a = "string" == typeof p,
                            c = p;
                            if (a) {
                                for (var h = new Uint8Array(p.length), i = 0; i < p.length; i++) h[i] = p.charCodeAt(i);
                                c = h.buffer
                            }
                            g[b++] = a ? 0 : 1;
                            for (var y = c.byteLength.toString(), i = 0; i < y.length; i++) g[b++] = parseInt(y[i]);
                            g[b++] = 255;
                            for (var h = new Uint8Array(c), i = 0; i < h.length; i++) g[b++] = h[i]
                        }),
                        c(g.buffer)
                    }) : c(new ArrayBuffer(0))
                },
                exports.encodePayloadAsBlob = function(a, c) {
                    function h(a, c) {
                        exports.encodePacket(a, !0, !0,
                        function(a) {
                            var h = new Uint8Array(1);
                            if (h[0] = 1, "string" == typeof a) {
                                for (var y = new Uint8Array(a.length), i = 0; i < a.length; i++) y[i] = a.charCodeAt(i);
                                a = y.buffer,
                                h[0] = 0
                            }
                            for (var g = a instanceof ArrayBuffer ? a.byteLength: a.size, b = g.toString(), v = new Uint8Array(b.length + 1), i = 0; i < b.length; i++) v[i] = parseInt(b[i]);
                            if (v[b.length] = 255, N) {
                                var w = new N([h.buffer, v.buffer, a]);
                                c(null, w)
                            }
                        })
                    }
                    v(a, h,
                    function(a, h) {
                        return c(new N(h))
                    })
                },
                exports.decodePayloadAsBinary = function(a, c, h) {
                    "function" == typeof c && (h = c, c = null);
                    for (var y = a,
                    g = [], b = !1; y.byteLength > 0;) {
                        for (var v = new Uint8Array(y), w = 0 === v[0], k = "", i = 1; 255 != v[i]; i++) {
                            if (k.length > 310) {
                                b = !0;
                                break
                            }
                            k += v[i]
                        }
                        if (b) return h(P, 0, 1);
                        y = A(y, 2 + k.length),
                        k = parseInt(k);
                        var B = A(y, 0, k);
                        if (w) try {
                            B = String.fromCharCode.apply(null, new Uint8Array(B))
                        } catch(e) {
                            var C = new Uint8Array(B);
                            B = "";
                            for (var i = 0; i < C.length; i++) B += String.fromCharCode(C[i])
                        }
                        g.push(B),
                        y = A(y, k)
                    }
                    var S = g.length;
                    g.forEach(function(a, i) {
                        h(exports.decodePacket(a, c, !0), i, S)
                    })
                }
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            "./keys": 28,
            after: 6,
            "arraybuffer.slice": 7,
            "base64-arraybuffer": 9,
            blob: 10,
            "has-binary": 29,
            utf8: 45
        }],
        28 : [function(a, module) {
            module.exports = Object.keys ||
            function(a) {
                var c = [],
                h = Object.prototype.hasOwnProperty;
                for (var i in a) h.call(a, i) && c.push(i);
                return c
            }
        },
        {}],
        29 : [function(a, module) { (function(c) {
                function h(a) {
                    function h(a) {
                        if (!a) return ! 1;
                        if (c.Buffer && c.Buffer.isBuffer(a) || c.ArrayBuffer && a instanceof ArrayBuffer || c.Blob && a instanceof Blob || c.File && a instanceof File) return ! 0;
                        if (y(a)) {
                            for (var i = 0; i < a.length; i++) if (h(a[i])) return ! 0
                        } else if (a && "object" == typeof a) {
                            a.toJSON && (a = a.toJSON());
                            for (var g in a) if (Object.prototype.hasOwnProperty.call(a, g) && h(a[g])) return ! 0
                        }
                        return ! 1
                    }
                    return h(a)
                }
                var y = a("isarray");
                module.exports = h
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            isarray: 34
        }],
        30 : [function(a, module) {
            module.exports = function() {
                return this
            } ()
        },
        {}],
        31 : [function(a, module) { (function(c) {
                function h(a) {
                    function h(a) {
                        if (!a) return ! 1;
                        if (c.Buffer && c.Buffer.isBuffer && c.Buffer.isBuffer(a) || c.ArrayBuffer && a instanceof ArrayBuffer || c.Blob && a instanceof Blob || c.File && a instanceof File) return ! 0;
                        if (y(a)) {
                            for (var i = 0; i < a.length; i++) if (h(a[i])) return ! 0
                        } else if (a && "object" == typeof a) {
                            a.toJSON && "function" == typeof a.toJSON && (a = a.toJSON());
                            for (var g in a) if (Object.prototype.hasOwnProperty.call(a, g) && h(a[g])) return ! 0
                        }
                        return ! 1
                    }
                    return h(a)
                }
                var y = a("isarray");
                module.exports = h
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            isarray: 34
        }],
        32 : [function(a, module) {
            var c = a("global");
            try {
                module.exports = "XMLHttpRequest" in c && "withCredentials" in new c.XMLHttpRequest
            } catch(h) {
                module.exports = !1
            }
        },
        {
            global: 30
        }],
        33 : [function(a, module) {
            var c = [].indexOf;
            module.exports = function(a, h) {
                if (c) return a.indexOf(h);
                for (var i = 0; i < a.length; ++i) if (a[i] === h) return i;
                return - 1
            }
        },
        {}],
        34 : [function(a, module) {
            module.exports = Array.isArray ||
            function(a) {
                return "[object Array]" == Object.prototype.toString.call(a)
            }
        },
        {}],
        35 : [function(a, module, exports) { (function(a) { (function() {
                    function c(a, exports) {
                        function h(a) {
                            if (h[a] !== T) return h[a];
                            var c;
                            if ("bug-string-char-index" == a) c = "a" != "a" [0];
                            else if ("json" == a) c = h("json-stringify") && h("json-parse");
                            else {
                                var y, b = "{"a":[1,true,false,null,"\\u0000\\b\\n\\f\\r\\t"]}";
                                if ("json-stringify" == a) {
                                    var w = exports.stringify,
                                    A = "function" == typeof w && P;
                                    if (A) { (y = function() {
                                            return 1
                                        }).toJSON = y;
                                        try {
                                            A = "0" === w(0) && "0" === w(new g) && """" == w(new v) && w(O) === T && w(T) === T && w() === T && "1" === w(y) && "[1]" == w([y]) && "[null]" == w([T]) && "null" == w(null) && "[null,null,null]" == w([T, O, null]) && w({
                                                a: [y, !0, !1, null, "\x00\b\n\f\r	"]
                                            }) == b && "1" === w(null, y) && "[\n 1,\n 2\n]" == w([1, 2], null, 1) && ""-271821-04-20T00:00:00.000Z"" == w(new k( - 864e13)) && ""+275760-09-13T00:00:00.000Z"" == w(new k(864e13)) && ""-000001-01-01T00:00:00.000Z"" == w(new k( - 621987552e5)) && ""1969-12-31T23:59:59.999Z"" == w(new k( - 1))
                                        } catch(B) {
                                            A = !1
                                        }
                                    }
                                    c = A
                                }
                                if ("json-parse" == a) {
                                    var C = exports.parse;
                                    if ("function" == typeof C) try {
                                        if (0 === C("0") && !C(!1)) {
                                            y = C(b);
                                            var S = 5 == y.a.length && 1 === y.a[0];
                                            if (S) {
                                                try {
                                                    S = !C(""	"")
                                                } catch(B) {}
                                                if (S) try {
                                                    S = 1 !== C("01")
                                                } catch(B) {}
                                                if (S) try {
                                                    S = 1 !== C("1.")
                                                } catch(B) {}
                                            }
                                        }
                                    } catch(B) {
                                        S = !1
                                    }
                                    c = S
                                }
                            }
                            return h[a] = !!c
                        }
                        a || (a = b.Object()),
                        exports || (exports = b.Object());
                        var g = a.Number || b.Number,
                        v = a.String || b.String,
                        w = a.Object || b.Object,
                        k = a.Date || b.Date,
                        A = a.SyntaxError || b.SyntaxError,
                        B = a.TypeError || b.TypeError,
                        C = a.Math || b.Math,
                        S = a.JSON || b.JSON;
                        "object" == typeof S && S && (exports.stringify = S.stringify, exports.parse = S.parse);
                        var E, _, T, j = w.prototype,
                        O = j.toString,
                        P = new k( - 0xc782b5b800cec);
                        try {
                            P = -109252 == P.getUTCFullYear() && 0 === P.getUTCMonth() && 1 === P.getUTCDate() && 10 == P.getUTCHours() && 37 == P.getUTCMinutes() && 6 == P.getUTCSeconds() && 708 == P.getUTCMilliseconds()
                        } catch(N) {}
                        if (!h("json")) {
                            var R = "[object Function]",
                            D = "[object Date]",
                            U = "[object Number]",
                            L = "[object String]",
                            M = "[object Array]",
                            I = "[object Boolean]",
                            H = h("bug-string-char-index");
                            if (!P) var z = C.floor,
                            J = [0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334],
                            X = function(a, c) {
                                return J[c] + 365 * (a - 1970) + z((a - 1969 + (c = +(c > 1))) / 4) - z((a - 1901 + c) / 100) + z((a - 1601 + c) / 400)
                            };
                            if ((E = j.hasOwnProperty) || (E = function(a) {
                                var c, h = {};
                                return (h.__proto__ = null, h.__proto__ = {
                                    toString: 1
                                },
                                h).toString != O ? E = function(a) {
                                    var c = this.__proto__,
                                    h = a in (this.__proto__ = null, this);
                                    return this.__proto__ = c,
                                    h
                                }: (c = h.constructor, E = function(a) {
                                    var h = (this.constructor || c).prototype;
                                    return a in this && !(a in h && this[a] === h[a])
                                }),
                                h = null,
                                E.call(this, a)
                            }), _ = function(a, c) {
                                var h, g, b, v = 0; (h = function() {
                                    this.valueOf = 0
                                }).prototype.valueOf = 0,
                                g = new h;
                                for (b in g) E.call(g, b) && v++;
                                return h = g = null,
                                v ? _ = 2 == v ?
                                function(a, c) {
                                    var h, y = {},
                                    g = O.call(a) == R;
                                    for (h in a) g && "prototype" == h || E.call(y, h) || !(y[h] = 1) || !E.call(a, h) || c(h)
                                }: function(a, c) {
                                    var h, y, g = O.call(a) == R;
                                    for (h in a) g && "prototype" == h || !E.call(a, h) || (y = "constructor" === h) || c(h); (y || E.call(a, h = "constructor")) && c(h)
                                }: (g = ["valueOf", "toString", "toLocaleString", "propertyIsEnumerable", "isPrototypeOf", "hasOwnProperty", "constructor"], _ = function(a, c) {
                                    var h, b, v = O.call(a) == R,
                                    w = !v && "function" != typeof a.constructor && y[typeof a.hasOwnProperty] && a.hasOwnProperty || E;
                                    for (h in a) v && "prototype" == h || !w.call(a, h) || c(h);
                                    for (b = g.length; h = g[--b]; w.call(a, h) && c(h));
                                }),
                                _(a, c)
                            },
                            !h("json-stringify")) {
                                var F = {
                                    92 : "\\\\",
                                    34 : "\\"",
                                    8 : "\\b",
                                    12 : "\\f",
                                    10 : "\\n",
                                    13 : "\\r",
                                    9 : "\\t"
                                },
                                Y = "000000",
                                $ = function(a, c) {
                                    return (Y + (c || 0)).slice( - a)
                                },
                                K = "\\u00",
                                W = function(a) {
                                    for (var c = """,
                                    h = 0,
                                    y = a.length,
                                    g = !H || y > 10,
                                    b = g && (H ? a.split("") : a); y > h; h++) {
                                        var v = a.charCodeAt(h);
                                        switch (v) {
                                        case 8:
                                        case 9:
                                        case 10:
                                        case 12:
                                        case 13:
                                        case 34:
                                        case 92:
                                            c += F[v];
                                            break;
                                        default:
                                            if (32 > v) {
                                                c += K + $(2, v.toString(16));
                                                break
                                            }
                                            c += g ? b[h] : a.charAt(h)
                                        }
                                    }
                                    return c + """
                                },
                                V = function(a, c, h, y, g, b, v) {
                                    var w, k, A, C, S, j, P, N, R, H, J, F, Y, K, Z, Q;
                                    try {
                                        w = c[a]
                                    } catch(G) {}
                                    if ("object" == typeof w && w) if (k = O.call(w), k != D || E.call(w, "toJSON"))"function" == typeof w.toJSON && (k != U && k != L && k != M || E.call(w, "toJSON")) && (w = w.toJSON(a));
                                    else if (w > -1 / 0 && 1 / 0 > w) {
                                        if (X) {
                                            for (S = z(w / 864e5), A = z(S / 365.2425) + 1970 - 1; X(A + 1, 0) <= S; A++);
                                            for (C = z((S - X(A, 0)) / 30.42); X(A, C + 1) <= S; C++);
                                            S = 1 + S - X(A, C),
                                            j = (w % 864e5 + 864e5) % 864e5,
                                            P = z(j / 36e5) % 24,
                                            N = z(j / 6e4) % 60,
                                            R = z(j / 1e3) % 60,
                                            H = j % 1e3
                                        } else A = w.getUTCFullYear(),
                                        C = w.getUTCMonth(),
                                        S = w.getUTCDate(),
                                        P = w.getUTCHours(),
                                        N = w.getUTCMinutes(),
                                        R = w.getUTCSeconds(),
                                        H = w.getUTCMilliseconds();
                                        w = (0 >= A || A >= 1e4 ? (0 > A ? "-": "+") + $(6, 0 > A ? -A: A) : $(4, A)) + "-" + $(2, C + 1) + "-" + $(2, S) + "T" + $(2, P) + ":" + $(2, N) + ":" + $(2, R) + "." + $(3, H) + "Z"
                                    } else w = null;
                                    if (h && (w = h.call(c, a, w)), null === w) return "null";
                                    if (k = O.call(w), k == I) return "" + w;
                                    if (k == U) return w > -1 / 0 && 1 / 0 > w ? "" + w: "null";
                                    if (k == L) return W("" + w);
                                    if ("object" == typeof w) {
                                        for (K = v.length; K--;) if (v[K] === w) throw B();
                                        if (v.push(w), J = [], Z = b, b += g, k == M) {
                                            for (Y = 0, K = w.length; K > Y; Y++) F = V(Y, w, h, y, g, b, v),
                                            J.push(F === T ? "null": F);
                                            Q = J.length ? g ? "[\n" + b + J.join(",\n" + b) + "\n" + Z + "]": "[" + J.join(",") + "]": "[]"
                                        } else _(y || w,
                                        function(a) {
                                            var c = V(a, w, h, y, g, b, v);
                                            c !== T && J.push(W(a) + ":" + (g ? " ": "") + c)
                                        }),
                                        Q = J.length ? g ? "{\n" + b + J.join(",\n" + b) + "\n" + Z + "}": "{" + J.join(",") + "}": "{}";
                                        return v.pop(),
                                        Q
                                    }
                                };
                                exports.stringify = function(a, c, h) {
                                    var g, b, v, w;
                                    if (y[typeof c] && c) if ((w = O.call(c)) == R) b = c;
                                    else if (w == M) {
                                        v = {};
                                        for (var k, A = 0,
                                        B = c.length; B > A; k = c[A++], w = O.call(k), (w == L || w == U) && (v[k] = 1));
                                    }
                                    if (h) if ((w = O.call(h)) == U) {
                                        if ((h -= h % 1) > 0) for (g = "", h > 10 && (h = 10); g.length < h; g += " ");
                                    } else w == L && (g = h.length <= 10 ? h: h.slice(0, 10));
                                    return V("", (k = {},
                                    k[""] = a, k), b, v, g, "", [])
                                }
                            }
                            if (!h("json-parse")) {
                                var Z, Q, G = v.fromCharCode,
                                te = {
                                    92 : "\\",
                                    34 : """,
                                    47 : "/",
                                    98 : "\b",
                                    116 : "	",
                                    110 : "\n",
                                    102 : "\f",
                                    114 : "\r"
                                },
                                ee = function() {
                                    throw Z = Q = null,
                                    A()
                                },
                                oe = function() {
                                    for (var a, c, h, y, g, b = Q,
                                    v = b.length; v > Z;) switch (g = b.charCodeAt(Z)) {
                                    case 9:
                                    case 10:
                                    case 13:
                                    case 32:
                                        Z++;
                                        break;
                                    case 123:
                                    case 125:
                                    case 91:
                                    case 93:
                                    case 58:
                                    case 44:
                                        return a = H ? b.charAt(Z) : b[Z],
                                        Z++,
                                        a;
                                    case 34:
                                        for (a = "@", Z++; v > Z;) if (g = b.charCodeAt(Z), 32 > g) ee();
                                        else if (92 == g) switch (g = b.charCodeAt(++Z)) {
                                        case 92:
                                        case 34:
                                        case 47:
                                        case 98:
                                        case 116:
                                        case 110:
                                        case 102:
                                        case 114:
                                            a += te[g],
                                            Z++;
                                            break;
                                        case 117:
                                            for (c = ++Z, h = Z + 4; h > Z; Z++) g = b.charCodeAt(Z),
                                            g >= 48 && 57 >= g || g >= 97 && 102 >= g || g >= 65 && 70 >= g || ee();
                                            a += G("0x" + b.slice(c, Z));
                                            break;
                                        default:
                                            ee()
                                        } else {
                                            if (34 == g) break;
                                            for (g = b.charCodeAt(Z), c = Z; g >= 32 && 92 != g && 34 != g;) g = b.charCodeAt(++Z);
                                            a += b.slice(c, Z)
                                        }
                                        if (34 == b.charCodeAt(Z)) return Z++,
                                        a;
                                        ee();
                                    default:
                                        if (c = Z, 45 == g && (y = !0, g = b.charCodeAt(++Z)), g >= 48 && 57 >= g) {
                                            for (48 == g && (g = b.charCodeAt(Z + 1), g >= 48 && 57 >= g) && ee(), y = !1; v > Z && (g = b.charCodeAt(Z), g >= 48 && 57 >= g); Z++);
                                            if (46 == b.charCodeAt(Z)) {
                                                for (h = ++Z; v > h && (g = b.charCodeAt(h), g >= 48 && 57 >= g); h++);
                                                h == Z && ee(),
                                                Z = h
                                            }
                                            if (g = b.charCodeAt(Z), 101 == g || 69 == g) {
                                                for (g = b.charCodeAt(++Z), (43 == g || 45 == g) && Z++, h = Z; v > h && (g = b.charCodeAt(h), g >= 48 && 57 >= g); h++);
                                                h == Z && ee(),
                                                Z = h
                                            }
                                            return + b.slice(c, Z)
                                        }
                                        if (y && ee(), "true" == b.slice(Z, Z + 4)) return Z += 4,
                                        !0;
                                        if ("false" == b.slice(Z, Z + 5)) return Z += 5,
                                        !1;
                                        if ("null" == b.slice(Z, Z + 4)) return Z += 4,
                                        null;
                                        ee()
                                    }
                                    return "$"
                                },
                                ie = function(a) {
                                    var c, h;
                                    if ("$" == a && ee(), "string" == typeof a) {
                                        if ("@" == (H ? a.charAt(0) : a[0])) return a.slice(1);
                                        if ("[" == a) {
                                            for (c = []; a = oe(), "]" != a; h || (h = !0)) h && ("," == a ? (a = oe(), "]" == a && ee()) : ee()),
                                            "," == a && ee(),
                                            c.push(ie(a));
                                            return c
                                        }
                                        if ("{" == a) {
                                            for (c = {}; a = oe(), "}" != a; h || (h = !0)) h && ("," == a ? (a = oe(), "}" == a && ee()) : ee()),
                                            ("," == a || "string" != typeof a || "@" != (H ? a.charAt(0) : a[0]) || ":" != oe()) && ee(),
                                            c[a.slice(1)] = ie(oe());
                                            return c
                                        }
                                        ee()
                                    }
                                    return a
                                },
                                se = function(a, c, h) {
                                    var y = ae(a, c, h);
                                    y === T ? delete a[c] : a[c] = y
                                },
                                ae = function(a, c, h) {
                                    var y, g = a[c];
                                    if ("object" == typeof g && g) if (O.call(g) == M) for (y = g.length; y--;) se(g, y, h);
                                    else _(g,
                                    function(a) {
                                        se(g, a, h)
                                    });
                                    return h.call(a, c, g)
                                };
                                exports.parse = function(a, c) {
                                    var h, y;
                                    return Z = 0,
                                    Q = "" + a,
                                    h = ie(oe()),
                                    "$" != oe() && ee(),
                                    Z = Q = null,
                                    c && O.call(c) == R ? ae((y = {},
                                    y[""] = h, y), "", c) : h
                                }
                            }
                        }
                        return exports.runInContext = c,
                        exports
                    }
                    var h = "function" == typeof define && define.amd,
                    y = {
                        "function": !0,
                        object: !0
                    },
                    g = y[typeof exports] && exports && !exports.nodeType && exports,
                    b = y[typeof window] && window || this,
                    v = g && y[typeof module] && module && !module.nodeType && "object" == typeof a && a;
                    if (!v || v.global !== v && v.window !== v && v.self !== v || (b = v), g && !h) c(b, g);
                    else {
                        var w = b.JSON,
                        k = b.JSON3,
                        A = !1,
                        B = c(b, b.JSON3 = {
                            noConflict: function() {
                                return A || (A = !0, b.JSON = w, b.JSON3 = k, w = k = null),
                                B
                            }
                        });
                        b.JSON = {
                            parse: B.parse,
                            stringify: B.stringify
                        }
                    }
                    h && define(function() {
                        return B
                    })
                }).call(this)
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {}],
        36 : [function(a, module) {
            function c(a) {
                if (a = "" + a, !(a.length > 1e4)) {
                    var c = /^((?:\d+)?\.?\d+) *(milliseconds?|msecs?|ms|seconds?|secs?|s|minutes?|mins?|m|hours?|hrs?|h|days?|d|years?|yrs?|y)?$/i.exec(a);
                    if (c) {
                        var n = parseFloat(c[1]),
                        h = (c[2] || "ms").toLowerCase();
                        switch (h) {
                        case "years":
                        case "year":
                        case "yrs":
                        case "yr":
                        case "y":
                            return n * v;
                        case "days":
                        case "day":
                        case "d":
                            return n * d;
                        case "hours":
                        case "hour":
                        case "hrs":
                        case "hr":
                        case "h":
                            return n * b;
                        case "minutes":
                        case "minute":
                        case "mins":
                        case "min":
                        case "m":
                            return n * m;
                        case "seconds":
                        case "second":
                        case "secs":
                        case "sec":
                        case "s":
                            return n * s;
                        case "milliseconds":
                        case "millisecond":
                        case "msecs":
                        case "msec":
                        case "ms":
                            return n
                        }
                    }
                }
            }
            function h(a) {
                return a >= d ? Math.round(a / d) + "d": a >= b ? Math.round(a / b) + "h": a >= m ? Math.round(a / m) + "m": a >= s ? Math.round(a / s) + "s": a + "ms"
            }
            function y(a) {
                return g(a, d, "day") || g(a, b, "hour") || g(a, m, "minute") || g(a, s, "second") || a + " ms"
            }
            function g(a, n, c) {
                return n > a ? void 0 : 1.5 * n > a ? Math.floor(a / n) + " " + c: Math.ceil(a / n) + " " + c + "s"
            }
            var s = 1e3,
            m = 60 * s,
            b = 60 * m,
            d = 24 * b,
            v = 365.25 * d;
            module.exports = function(a, g) {
                return g = g || {},
                "string" == typeof a ? c(a) : g.long ? y(a) : h(a)
            }
        },
        {}],
        37 : [function(a, module) { (function(a) {
                var c = /^[\],:{}\s]*$/,
                h = /\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g,
                y = /"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,
                g = /(?:^|:|,)(?:\s*\[)+/g,
                b = /^\s+/,
                v = /\s+$/;
                module.exports = function(w) {
                    return "string" == typeof w && w ? (w = w.replace(b, "").replace(v, ""), a.JSON && JSON.parse ? JSON.parse(w) : c.test(w.replace(h, "@").replace(y, "]").replace(g, "")) ? new Function("return " + w)() : void 0) : null
                }
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {}],
        38 : [function(a, module, exports) {
            exports.encode = function(a) {
                var c = "";
                for (var i in a) a.hasOwnProperty(i) && (c.length && (c += "&"), c += encodeURIComponent(i) + "=" + encodeURIComponent(a[i]));
                return c
            },
            exports.decode = function(a) {
                for (var c = {},
                h = a.split("&"), i = 0, l = h.length; l > i; i++) {
                    var y = h[i].split("=");
                    c[decodeURIComponent(y[0])] = decodeURIComponent(y[1])
                }
                return c
            }
        },
        {}],
        39 : [function(a, module) {
            var re = /^(?:(?![^:@]+:[^:@\/]*@)(http|https|ws|wss):\/\/)?((?:(([^:@]*)(?::([^:@]*))?)?@)?((?:[a-f0-9]{0,4}:){2,7}[a-f0-9]{0,4}|[^:\/?#]*)(?::(\d*))?)(((\/(?:[^?#](?![^?#\/]*\.[^?#\/.]+(?:[?#]|$)))*\/?)?([^?#\/]*))(?:\?([^#]*))?(?:#(.*))?)/,
            c = ["source", "protocol", "authority", "userInfo", "user", "password", "host", "port", "relative", "path", "directory", "file", "query", "anchor"];
            module.exports = function(a) {
                var h = a,
                y = a.indexOf("["),
                e = a.indexOf("]"); - 1 != y && -1 != e && (a = a.substring(0, y) + a.substring(y, e).replace(/:/g, ";") + a.substring(e, a.length));
                for (var m = re.exec(a || ""), g = {},
                i = 14; i--;) g[c[i]] = m[i] || "";
                return - 1 != y && -1 != e && (g.source = h, g.host = g.host.substring(1, g.host.length - 1).replace(/;/g, ":"), g.authority = g.authority.replace("[", "").replace("]", "").replace(/;/g, ":"), g.ipv6uri = !0),
                g
            }
        },
        {}],
        40 : [function(a, module, exports) { (function(c) {
                var h = a("isarray"),
                y = a("./is-buffer");
                exports.deconstructPacket = function(a) {
                    function c(a) {
                        if (!a) return a;
                        if (y(a)) {
                            var b = {
                                _placeholder: !0,
                                num: g.length
                            };
                            return g.push(a),
                            b
                        }
                        if (h(a)) {
                            for (var v = new Array(a.length), i = 0; i < a.length; i++) v[i] = c(a[i]);
                            return v
                        }
                        if ("object" == typeof a && !(a instanceof Date)) {
                            var v = {};
                            for (var w in a) v[w] = c(a[w]);
                            return v
                        }
                        return a
                    }
                    var g = [],
                    b = a.data,
                    v = a;
                    return v.data = c(b),
                    v.attachments = g.length,
                    {
                        packet: v,
                        buffers: g
                    }
                },
                exports.reconstructPacket = function(a, c) {
                    function y(a) {
                        if (a && a._placeholder) {
                            var g = c[a.num];
                            return g
                        }
                        if (h(a)) {
                            for (var i = 0; i < a.length; i++) a[i] = y(a[i]);
                            return a
                        }
                        if (a && "object" == typeof a) {
                            for (var b in a) a[b] = y(a[b]);
                            return a
                        }
                        return a
                    }
                    return a.data = y(a.data),
                    a.attachments = void 0,
                    a
                },
                exports.removeBlobs = function(a, g) {
                    function b(a, k, A) {
                        if (!a) return a;
                        if (c.Blob && a instanceof Blob || c.File && a instanceof File) {
                            v++;
                            var B = new FileReader;
                            B.onload = function() {
                                A ? A[k] = this.result: w = this.result,
                                --v || g(w)
                            },
                            B.readAsArrayBuffer(a)
                        } else if (h(a)) for (var i = 0; i < a.length; i++) b(a[i], i, a);
                        else if (a && "object" == typeof a && !y(a)) for (var C in a) b(a[C], C, a)
                    }
                    var v = 0,
                    w = a;
                    b(w),
                    v || g(w)
                }
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {
            "./is-buffer": 42,
            isarray: 34
        }],
        41 : [function(a, module, exports) {
            function c() {}
            function h(a) {
                var c = "",
                h = !1;
                return c += a.type,
                (exports.BINARY_EVENT == a.type || exports.BINARY_ACK == a.type) && (c += a.attachments, c += "-"),
                a.nsp && "/" != a.nsp && (h = !0, c += a.nsp),
                null != a.id && (h && (c += ",", h = !1), c += a.id),
                null != a.data && (h && (c += ","), c += A.stringify(a.data)),
                k("encoded %j as %s", a, c),
                c
            }
            function y(a, c) {
                function y(a) {
                    var y = C.deconstructPacket(a),
                    g = h(y.packet),
                    b = y.buffers;
                    b.unshift(g),
                    c(b)
                }
                C.removeBlobs(a, y)
            }
            function g() {
                this.reconstructor = null
            }
            function b(a) {
                var p = {},
                i = 0;
                if (p.type = Number(a.charAt(0)), null == exports.types[p.type]) return w();
                if (exports.BINARY_EVENT == p.type || exports.BINARY_ACK == p.type) {
                    for (var c = "";
                    "-" != a.charAt(++i) && (c += a.charAt(i), i != a.length););
                    if (c != Number(c) || "-" != a.charAt(i)) throw new Error("Illegal attachments");
                    p.attachments = Number(c)
                }
                if ("/" == a.charAt(i + 1)) for (p.nsp = ""; ++i;) {
                    var h = a.charAt(i);
                    if ("," == h) break;
                    if (p.nsp += h, i == a.length) break
                } else p.nsp = "/";
                var y = a.charAt(i + 1);
                if ("" !== y && Number(y) == y) {
                    for (p.id = ""; ++i;) {
                        var h = a.charAt(i);
                        if (null == h || Number(h) != h) {--i;
                            break
                        }
                        if (p.id += a.charAt(i), i == a.length) break
                    }
                    p.id = Number(p.id)
                }
                if (a.charAt(++i)) try {
                    p.data = A.parse(a.substr(i))
                } catch(e) {
                    return w()
                }
                return k("decoded %s as %j", a, p),
                p
            }
            function v(a) {
                this.reconPack = a,
                this.buffers = []
            }
            function w() {
                return {
                    type: exports.ERROR,
                    data: "parser error"
                }
            }
            var k = a("debug")("socket.io-parser"),
            A = a("json3"),
            B = (a("isarray"), a("component-emitter")),
            C = a("./binary"),
            S = a("./is-buffer");
            exports.protocol = 4,
            exports.types = ["CONNECT", "DISCONNECT", "EVENT", "BINARY_EVENT", "ACK", "BINARY_ACK", "ERROR"],
            exports.CONNECT = 0,
            exports.DISCONNECT = 1,
            exports.EVENT = 2,
            exports.ACK = 3,
            exports.ERROR = 4,
            exports.BINARY_EVENT = 5,
            exports.BINARY_ACK = 6,
            exports.Encoder = c,
            exports.Decoder = g,
            c.prototype.encode = function(a, c) {
                if (k("encoding packet %j", a), exports.BINARY_EVENT == a.type || exports.BINARY_ACK == a.type) y(a, c);
                else {
                    var g = h(a);
                    c([g])
                }
            },
            B(g.prototype),
            g.prototype.add = function(a) {
                var c;
                if ("string" == typeof a) c = b(a),
                exports.BINARY_EVENT == c.type || exports.BINARY_ACK == c.type ? (this.reconstructor = new v(c), 0 === this.reconstructor.reconPack.attachments && this.emit("decoded", c)) : this.emit("decoded", c);
                else {
                    if (!S(a) && !a.base64) throw new Error("Unknown type: " + a);
                    if (!this.reconstructor) throw new Error("got binary data when not reconstructing a packet");
                    c = this.reconstructor.takeBinaryData(a),
                    c && (this.reconstructor = null, this.emit("decoded", c))
                }
            },
            g.prototype.destroy = function() {
                this.reconstructor && this.reconstructor.finishedReconstruction()
            },
            v.prototype.takeBinaryData = function(a) {
                if (this.buffers.push(a), this.buffers.length == this.reconPack.attachments) {
                    var c = C.reconstructPacket(this.reconPack, this.buffers);
                    return this.finishedReconstruction(),
                    c
                }
                return null
            },
            v.prototype.finishedReconstruction = function() {
                this.reconPack = null,
                this.buffers = []
            }
        },
        {
            "./binary": 40,
            "./is-buffer": 42,
            "component-emitter": 43,
            debug: 14,
            isarray: 34,
            json3: 35
        }],
        42 : [function(a, module) { (function(a) {
                function c(c) {
                    return a.Buffer && a.Buffer.isBuffer(c) || a.ArrayBuffer && c instanceof ArrayBuffer
                }
                module.exports = c
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {}],
        43 : [function(a, module, exports) {
            arguments[4][26][0].apply(exports, arguments)
        },
        {
            dup: 26
        }],
        44 : [function(a, module) {
            function c(a, c) {
                var h = [];
                c = c || 0;
                for (var i = c || 0; i < a.length; i++) h[i - c] = a[i];
                return h
            }
            module.exports = c
        },
        {}],
        45 : [function(a, module, exports) { (function(a) { !
                function(c) {
                    function h(a) {
                        for (var c, h, y = [], g = 0, b = a.length; b > g;) c = a.charCodeAt(g++),
                        c >= 55296 && 56319 >= c && b > g ? (h = a.charCodeAt(g++), 56320 == (64512 & h) ? y.push(((1023 & c) << 10) + (1023 & h) + 65536) : (y.push(c), g--)) : y.push(c);
                        return y
                    }
                    function y(a) {
                        for (var c, h = a.length,
                        y = -1,
                        g = ""; ++y < h;) c = a[y],
                        c > 65535 && (c -= 65536, g += O(c >>> 10 & 1023 | 55296), c = 56320 | 1023 & c),
                        g += O(c);
                        return g
                    }
                    function g(a) {
                        if (a >= 55296 && 57343 >= a) throw Error("Lone surrogate U+" + a.toString(16).toUpperCase() + " is not a scalar value")
                    }
                    function b(a, c) {
                        return O(a >> c & 63 | 128)
                    }
                    function v(a) {
                        if (0 == (4294967168 & a)) return O(a);
                        var c = "";
                        return 0 == (4294965248 & a) ? c = O(a >> 6 & 31 | 192) : 0 == (4294901760 & a) ? (g(a), c = O(a >> 12 & 15 | 224), c += b(a, 6)) : 0 == (4292870144 & a) && (c = O(a >> 18 & 7 | 240), c += b(a, 12), c += b(a, 6)),
                        c += O(63 & a | 128)
                    }
                    function w(a) {
                        for (var c, y = h(a), g = y.length, b = -1, w = ""; ++b < g;) c = y[b],
                        w += v(c);
                        return w
                    }
                    function k() {
                        if (j >= T) throw Error("Invalid byte index");
                        var a = 255 & _[j];
                        if (j++, 128 == (192 & a)) return 63 & a;
                        throw Error("Invalid continuation byte")
                    }
                    function A() {
                        var a, c, h, y, b;
                        if (j > T) throw Error("Invalid byte index");
                        if (j == T) return ! 1;
                        if (a = 255 & _[j], j++, 0 == (128 & a)) return a;
                        if (192 == (224 & a)) {
                            var c = k();
                            if (b = (31 & a) << 6 | c, b >= 128) return b;
                            throw Error("Invalid continuation byte")
                        }
                        if (224 == (240 & a)) {
                            if (c = k(), h = k(), b = (15 & a) << 12 | c << 6 | h, b >= 2048) return g(b),
                            b;
                            throw Error("Invalid continuation byte")
                        }
                        if (240 == (248 & a) && (c = k(), h = k(), y = k(), b = (15 & a) << 18 | c << 12 | h << 6 | y, b >= 65536 && 1114111 >= b)) return b;
                        throw Error("Invalid UTF-8 detected")
                    }
                    function B(a) {
                        _ = h(a),
                        T = _.length,
                        j = 0;
                        for (var c, g = []; (c = A()) !== !1;) g.push(c);
                        return y(g)
                    }
                    var C = "object" == typeof exports && exports,
                    S = "object" == typeof module && module && module.exports == C && module,
                    E = "object" == typeof a && a; (E.global === E || E.window === E) && (c = E);
                    var _, T, j, O = String.fromCharCode,
                    P = {
                        version: "2.0.0",
                        encode: w,
                        decode: B
                    };
                    if ("function" == typeof define && "object" == typeof define.amd && define.amd) define(function() {
                        return P
                    });
                    else if (C && !C.nodeType) if (S) S.exports = P;
                    else {
                        var N = {},
                        R = N.hasOwnProperty;
                        for (var D in P) R.call(P, D) && (C[D] = P[D])
                    } else c.utf8 = P
                } (this)
            }).call(this, "undefined" != typeof self ? self: "undefined" != typeof window ? window: "undefined" != typeof global ? global: {})
        },
        {}],
        46 : [function(a, module) {
            "use strict";
            function c(a) {
                var c = "";
                do c = b[a % v] + c,
                a = Math.floor(a / v);
                while (a > 0);
                return c
            }
            function h(a) {
                var c = 0;
                for (i = 0; i < a.length; i++) c = c * v + w[a.charAt(i)];
                return c
            }
            function y() {
                var a = c( + new Date);
                return a !== g ? (k = 0, g = a) : a + "." + c(k++)
            }
            for (var g, b = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_".split(""), v = 64, w = {},
            k = 0, i = 0; v > i; i++) w[b[i]] = i;
            y.encode = c,
            y.decode = h,
            module.exports = y
        },
        {}]
    },
    {},
    [1])(1)
});
/*!common/widgets/passport/dep/socketio-java/moment.min.js*/
; !
function(a, c) {
    function h(a, c) {
        this._d = a,
        this._isUTC = !!c
    }
    function M(a) {
        return 0 > a ? Math.ceil(a) : Math.floor(a)
    }
    function D(a) {
        var c = this._data = {},
        h = a.years || a.y || 0,
        d = a.months || a.M || 0,
        e = a.weeks || a.w || 0,
        f = a.days || a.d || 0,
        D = a.hours || a.h || 0,
        y = a.minutes || a.m || 0,
        i = a.seconds || a.s || 0,
        _ = a.milliseconds || a.ms || 0;
        this._milliseconds = _ + 1e3 * i + 6e4 * y + 36e5 * D,
        this._days = f + 7 * e,
        this._months = d + 12 * h,
        c.milliseconds = _ % 1e3,
        i += M(_ / 1e3),
        c.seconds = i % 60,
        y += M(i / 60),
        c.minutes = y % 60,
        D += M(y / 60),
        c.hours = D % 24,
        f += M(D / 24),
        f += 7 * e,
        c.days = f % 30,
        d += M(f / 30),
        c.months = d % 12,
        h += M(d / 12),
        c.years = h
    }
    function y(a, c) {
        for (var h = a + ""; h.length < c;) h = "0" + h;
        return h
    }
    function _(a, c, h) {
        var M, d = c._milliseconds,
        e = c._days,
        f = c._months;
        d && a._d.setTime( + a + d * h),
        e && a.date(a.date() + e * h),
        f && (M = a.date(), a.date(1).month(a.month() + f * h).date(Math.min(M, a.daysInMonth())))
    }
    function Y(a) {
        return "[object Array]" === Object.prototype.toString.call(a)
    }
    function w(c) {
        return new a(c[0], c[1] || 0, c[2] || 1, c[3] || 0, c[4] || 0, c[5] || 0, c[6] || 0)
    }
    function T(c, d) {
        function q(d) {
            var l, r;
            switch (d) {
            case "M":
                return e + 1;
            case "Mo":
                return e + 1 + o(e + 1);
            case "MM":
                return y(e + 1, 2);
            case "MMM":
                return A.monthsShort[e];
            case "MMMM":
                return A.months[e];
            case "D":
                return f;
            case "Do":
                return f + o(f);
            case "DD":
                return y(f, 2);
            case "DDD":
                return l = new a(h, e, f),
                r = new a(h, 0, 1),
                ~~ ((l - r) / 864e5 + 1.5);
            case "DDDo":
                return l = q("DDD"),
                l + o(l);
            case "DDDD":
                return y(q("DDD"), 3);
            case "d":
                return M;
            case "do":
                return M + o(M);
            case "ddd":
                return A.weekdaysShort[M];
            case "dddd":
                return A.weekdays[M];
            case "w":
                return l = new a(h, e, f - M + 5),
                r = new a(l.getFullYear(), 0, 4),
                ~~ ((l - r) / 864e5 / 7 + 1.5);
            case "wo":
                return l = q("w"),
                l + o(l);
            case "ww":
                return y(q("w"), 2);
            case "YY":
                return y(h % 100, 2);
            case "YYYY":
                return h;
            case "a":
                return p ? p(i, D, !1) : i > 11 ? "pm": "am";
            case "A":
                return p ? p(i, D, !0) : i > 11 ? "PM": "AM";
            case "H":
                return i;
            case "HH":
                return y(i, 2);
            case "h":
                return i % 12 || 12;
            case "hh":
                return y(i % 12 || 12, 2);
            case "m":
                return D;
            case "mm":
                return y(D, 2);
            case "s":
                return _;
            case "ss":
                return y(_, 2);
            case "S":
                return~~ (m / 100);
            case "SS":
                return y(~~ (m / 10), 2);
            case "SSS":
                return y(m, 3);
            case "Z":
                return (0 > n ? "-": "+") + y(~~ (Math.abs(n) / 60), 2) + ":" + y(~~ (Math.abs(n) % 60), 2);
            case "ZZ":
                return (0 > n ? "-": "+") + y(~~ (10 * Math.abs(n) / 6), 4);
            case "L":
            case "LL":
            case "LLL":
            case "LLLL":
            case "LT":
                return T(c, A.longDateFormat[d]);
            default:
                return d.replace(/(^\[)|(\\)|\]$/g, "")
            }
        }
        var e = c.month(),
        f = c.date(),
        h = c.year(),
        M = c.day(),
        i = c.hours(),
        D = c.minutes(),
        _ = c.seconds(),
        m = c.milliseconds(),
        n = -c.zone(),
        o = A.ordinal,
        p = A.meridiem;
        return d.replace(l, q)
    }
    function S(a) {
        switch (a) {
        case "DDDD":
            return p;
        case "YYYY":
            return q;
        case "S":
        case "SS":
        case "SSS":
        case "DDD":
            return o;
        case "MMM":
        case "MMMM":
        case "ddd":
        case "dddd":
        case "a":
        case "A":
            return r;
        case "Z":
        case "ZZ":
            return s;
        case "T":
            return t;
        case "MM":
        case "DD":
        case "dd":
        case "YY":
        case "HH":
        case "hh":
        case "mm":
        case "ss":
        case "M":
        case "D":
        case "d":
        case "H":
        case "h":
        case "m":
        case "s":
            return n;
        default:
            return new RegExp(a.replace("\\", ""))
        }
    }
    function L(a, c, d, e) {
        var f;
        switch (a) {
        case "M":
        case "MM":
            d[1] = null == c ? 0 : ~~c - 1;
            break;
        case "MMM":
        case "MMMM":
            for (f = 0; 12 > f; f++) if (A.monthsParse[f].test(c)) {
                d[1] = f;
                break
            }
            break;
        case "D":
        case "DD":
        case "DDD":
        case "DDDD":
            d[2] = ~~c;
            break;
        case "YY":
            c = ~~c,
            d[0] = c + (c > 70 ? 1900 : 2e3);
            break;
        case "YYYY":
            d[0] = ~~Math.abs(c);
            break;
        case "a":
        case "A":
            e.isPm = "pm" === (c + "").toLowerCase();
            break;
        case "H":
        case "HH":
        case "h":
        case "hh":
            d[3] = ~~c;
            break;
        case "m":
        case "mm":
            d[4] = ~~c;
            break;
        case "s":
        case "ss":
            d[5] = ~~c;
            break;
        case "S":
        case "SS":
        case "SSS":
            d[6] = ~~ (1e3 * ("0." + c));
            break;
        case "Z":
        case "ZZ":
            e.isUTC = !0,
            f = (c + "").match(x),
            f && f[1] && (e.tzh = ~~f[1]),
            f && f[2] && (e.tzm = ~~f[2]),
            f && "+" === f[0] && (e.tzh = -e.tzh, e.tzm = -e.tzm)
        }
    }
    function g(c, h) {
        var M, D, d = [0, 0, 1, 0, 0, 0, 0],
        e = {
            tzh: 0,
            tzm: 0
        },
        f = h.match(l);
        for (M = 0; M < f.length; M++) D = (S(f[M]).exec(c) || [])[0],
        c = c.replace(S(f[M]), ""),
        L(f[M], D, d, e);
        return e.isPm && d[3] < 12 && (d[3] += 12),
        e.isPm === !1 && 12 === d[3] && (d[3] = 0),
        d[3] += e.tzh,
        d[4] += e.tzm,
        e.isUTC ? new a(a.UTC.apply({},
        d)) : w(d)
    }
    function v(a, c) {
        var f, h = Math.min(a.length, c.length),
        d = Math.abs(a.length - c.length),
        e = 0;
        for (f = 0; h > f; f++)~~a[f] !== ~~c[f] && e++;
        return e + d
    }
    function F(a, c) {
        var M, e, D, y, i, d = a.match(m) || [],
        f = 99;
        for (D = 0; D < c.length; D++) y = g(a, c[D]),
        e = T(new h(y), c[D]).match(m) || [],
        i = v(d, e),
        f > i && (f = i, M = y);
        return M
    }
    function b(c) {
        var d, h = "YYYY-MM-DDT";
        if (u.exec(c)) {
            for (d = 0; 4 > d; d++) if (J[d][1].exec(c)) {
                h += J[d][0];
                break
            }
            return s.exec(c) ? g(c, h + " Z") : g(c, h)
        }
        return new a(c)
    }
    function k(a, c, d, e) {
        var f = A.relativeTime[a];
        return "function" == typeof f ? f(c || 1, !!d, a, e) : f.replace(/%d/i, c || 1)
    }
    function z(a, c) {
        var h = e(Math.abs(a) / 1e3),
        d = e(h / 60),
        f = e(d / 60),
        M = e(f / 24),
        D = e(M / 365),
        i = 45 > h && ["s", h] || 1 === d && ["m"] || 45 > d && ["mm", d] || 1 === f && ["h"] || 22 > f && ["hh", f] || 1 === M && ["d"] || 25 >= M && ["dd", M] || 45 >= M && ["M"] || 345 > M && ["MM", e(M / 30)] || 1 === D && ["y"] || ["yy", D];
        return i[2] = c,
        i[3] = a > 0,
        k.apply({},
        i)
    }
    function H(a, c) {
        A.fn[a] = function(a) {
            var h = this._isUTC ? "UTC": "";
            return null != a ? (this._d["set" + h + c](a), this) : this._d["get" + h + c]()
        }
    }
    function C(a) {
        A.duration.fn[a] = function() {
            return this._data[a]
        }
    }
    function Z(a, c) {
        A.duration.fn["as" + a] = function() {
            return + this / c
        }
    }
    var A, f, d = "1.6.2",
    e = Math.round,
    U = {},
    P = "en",
    i = "undefined" != typeof module,
    O = "months|monthsShort|monthsParse|weekdays|weekdaysShort|longDateFormat|calendar|relativeTime|ordinal|meridiem".split("|"),
    W = /^\/?Date\((\-?\d+)/i,
    l = /(\[[^\[]*\])|(\\)?(Mo|MM?M?M?|Do|DDDo|DD?D?D?|dddd?|do?|w[o|w]?|YYYY|YY|a|A|hh?|HH?|mm?|ss?|SS?S?|zz?|ZZ?|LT|LL?L?L?)/g,
    m = /([0-9a-zA-Z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)/gi,
    n = /\d\d?/,
    o = /\d{1,3}/,
    p = /\d{3}/,
    q = /\d{4}/,
    r = /[0-9a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+/i,
    s = /Z|[\+\-]\d\d:?\d\d/i,
    t = /T/i,
    u = /^\s*\d{4}-\d\d-\d\d(T(\d\d(:\d\d(:\d\d(\.\d\d?\d?)?)?)?)?([\+\-]\d\d:?\d\d)?)?/,
    E = "YYYY-MM-DDTHH:mm:ssZ",
    J = [["HH:mm:ss.S", /T\d\d:\d\d:\d\d\.\d{1,3}/], ["HH:mm:ss", /T\d\d:\d\d:\d\d/], ["HH:mm", /T\d\d:\d\d/], ["HH", /T\d\d/]],
    x = /([\+\-]|\d\d)/gi,
    j = "Month|Date|Hours|Minutes|Seconds|Milliseconds".split("|"),
    N = {
        Milliseconds: 1,
        Seconds: 1e3,
        Minutes: 6e4,
        Hours: 36e5,
        Days: 864e5,
        Months: 2592e6,
        Years: 31536e6
    };
    for (A = function(d, e) {
        if (null === d || "" === d) return null;
        var f, M, D;
        return A.isMoment(d) ? (f = new a( + d._d), D = d._isUTC) : e ? f = Y(e) ? F(d, e) : g(d, e) : (M = W.exec(d), f = d === c ? new a: M ? new a( + M[1]) : d instanceof a ? d: Y(d) ? w(d) : "string" == typeof d ? b(d) : new a(d)),
        new h(f, D)
    },
    A.utc = function(c, d) {
        return Y(c) ? new h(new a(a.UTC.apply({},
        c)), !0) : d && c ? A(c + " +0000", d + " Z").utc() : A(c && !s.exec(c) ? c + "+0000": c).utc()
    },
    A.unix = function(a) {
        return A(1e3 * a)
    },
    A.duration = function(a, c) {
        var d = A.isDuration(a),
        e = "number" == typeof a,
        f = d ? a._data: e ? {}: a;
        return e && (c ? f[c] = a: f.milliseconds = a),
        new D(f)
    },
    A.humanizeDuration = function(a, c, d) {
        return A.duration(a, c === !0 ? null: c).humanize(c === !0 ? !0 : d)
    },
    A.version = d, A.defaultFormat = E, A.lang = function(a, c) {
        var d, e, f = [];
        if (!a) return P;
        if (c) {
            for (d = 0; 12 > d; d++) f[d] = new RegExp("^" + c.months[d] + "|^" + c.monthsShort[d].replace(".", ""), "i");
            c.monthsParse = c.monthsParse || f,
            U[a] = c
        }
        if (U[a]) {
            for (d = 0; d < O.length; d++) A[O[d]] = U[a][O[d]] || U.en[O[d]];
            P = a
        } else i && (e = require("./lang/" + a), A.lang(a, e))
    },
    A.lang("en", {
        months: "January_February_March_April_May_June_July_August_September_October_November_December".split("_"),
        monthsShort: "Jan_Feb_Mar_Apr_May_Jun_Jul_Aug_Sep_Oct_Nov_Dec".split("_"),
        weekdays: "Sunday_Monday_Tuesday_Wednesday_Thursday_Friday_Saturday".split("_"),
        weekdaysShort: "Sun_Mon_Tue_Wed_Thu_Fri_Sat".split("_"),
        longDateFormat: {
            LT: "h:mm A",
            L: "MM/DD/YYYY",
            LL: "MMMM D YYYY",
            LLL: "MMMM D YYYY LT",
            LLLL: "dddd, MMMM D YYYY LT"
        },
        meridiem: !1,
        calendar: {
            sameDay: "[Today at] LT",
            nextDay: "[Tomorrow at] LT",
            nextWeek: "dddd [at] LT",
            lastDay: "[Yesterday at] LT",
            lastWeek: "[last] dddd [at] LT",
            sameElse: "L"
        },
        relativeTime: {
            future: "in %s",
            past: "%s ago",
            s: "a few seconds",
            m: "a minute",
            mm: "%d minutes",
            h: "an hour",
            hh: "%d hours",
            d: "a day",
            dd: "%d days",
            M: "a month",
            MM: "%d months",
            y: "a year",
            yy: "%d years"
        },
        ordinal: function(a) {
            var c = a % 10;
            return 1 === ~~ (a % 100 / 10) ? "th": 1 === c ? "st": 2 === c ? "nd": 3 === c ? "rd": "th"
        }
    }), A.isMoment = function(a) {
        return a instanceof h
    },
    A.isDuration = function(a) {
        return a instanceof D
    },
    A.fn = h.prototype = {
        clone: function() {
            return A(this)
        },
        valueOf: function() {
            return + this._d
        },
        unix: function() {
            return Math.floor( + this._d / 1e3)
        },
        toString: function() {
            return this._d.toString()
        },
        toDate: function() {
            return this._d
        },
        utc: function() {
            return this._isUTC = !0,
            this
        },
        local: function() {
            return this._isUTC = !1,
            this
        },
        format: function(a) {
            return T(this, a ? a: A.defaultFormat)
        },
        add: function(a, c) {
            var d = c ? A.duration( + c, a) : A.duration(a);
            return _(this, d, 1),
            this
        },
        subtract: function(a, c) {
            var d = c ? A.duration( + c, a) : A.duration(a);
            return _(this, d, -1),
            this
        },
        diff: function(a, c, d) {
            var l, f = this._isUTC ? A(a).utc() : A(a).local(),
            h = 6e4 * (this.zone() - f.zone()),
            M = this._d - f._d - h,
            i = this.year() - f.year(),
            D = this.month() - f.month(),
            y = this.date() - f.date();
            return l = "months" === c ? 12 * i + D + y / 30 : "years" === c ? i + (D + y / 30) / 12 : "seconds" === c ? M / 1e3: "minutes" === c ? M / 6e4: "hours" === c ? M / 36e5: "days" === c ? M / 864e5: "weeks" === c ? M / 6048e5: M,
            d ? l: e(l)
        },
        from: function(a, c) {
            return A.duration(this.diff(a)).humanize(!c)
        },
        fromNow: function(a) {
            return this.from(A(), a)
        },
        calendar: function() {
            var a = this.diff(A().sod(), "days", !0),
            c = A.calendar,
            d = c.sameElse,
            e = -6 > a ? d: -1 > a ? c.lastWeek: 0 > a ? c.lastDay: 1 > a ? c.sameDay: 2 > a ? c.nextDay: 7 > a ? c.nextWeek: d;
            return this.format("function" == typeof e ? e.apply(this) : e)
        },
        isLeapYear: function() {
            var a = this.year();
            return a % 4 === 0 && a % 100 !== 0 || a % 400 === 0
        },
        isDST: function() {
            return this.zone() < A([this.year()]).zone() || this.zone() < A([this.year(), 5]).zone()
        },
        day: function(a) {
            var c = this._isUTC ? this._d.getUTCDay() : this._d.getDay();
            return null == a ? c: this.add({
                d: a - c
            })
        },
        sod: function() {
            return A(this).hours(0).minutes(0).seconds(0).milliseconds(0)
        },
        eod: function() {
            return this.sod().add({
                d: 1,
                ms: -1
            })
        },
        zone: function() {
            return this._isUTC ? 0 : this._d.getTimezoneOffset()
        },
        daysInMonth: function() {
            return A(this).month(this.month() + 1).date(0).date()
        }
    },
    f = 0; f < j.length; f++) H(j[f].toLowerCase(), j[f]);
    H("year", "FullYear"),
    A.duration.fn = D.prototype = {
        weeks: function() {
            return M(this.days() / 7)
        },
        valueOf: function() {
            return this._milliseconds + 864e5 * this._days + 2592e6 * this._months
        },
        humanize: function(a) {
            var c = +this,
            d = A.relativeTime,
            e = z(c, !a);
            return a && (e = (0 >= c ? d.past: d.future).replace(/%s/i, e)),
            e
        }
    };
    for (f in N) N.hasOwnProperty(f) && (Z(f, N[f]), C(f.toLowerCase()));
    Z("Weeks", 6048e5),
    i && (module.exports = A),
    "undefined" != typeof window && "undefined" == typeof ender && (window.moment = A),
    "function" == typeof define && define.amd && define("common/widgets/passport/dep/socketio-java/moment.min", ["require"],
    function() {
        return A
    })
} (Date);
/*!common/widgets/passport/dep/jquery.qrcode/jquery.qrcode.min.js*/
;
define("common/widgets/passport/dep/jquery.qrcode/jquery.qrcode.min", ["require", "exports", "module"],
function() { !
    function(r) {
        r.fn.qrcode = function(a) {
            function u(a) {
                this.mode = s,
                this.data = a
            }
            function o(a, h) {
                this.typeNumber = a,
                this.errorCorrectLevel = h,
                this.modules = null,
                this.moduleCount = 0,
                this.dataCache = null,
                this.dataList = []
            }
            function q(a, h) {
                if (void 0 == a.length) throw Error(a.length + "/" + h);
                for (var d = 0; d < a.length && 0 == a[d];) d++;
                this.num = Array(a.length - d + h);
                for (var g = 0; g < a.length - d; g++) this.num[g] = a[g + d]
            }
            function p(a, h) {
                this.totalCount = a,
                this.dataCount = h
            }
            function t() {
                this.buffer = [],
                this.length = 0
            }
            var s;
            u.prototype = {
                getLength: function() {
                    return this.data.length
                },
                write: function(a) {
                    for (var h = 0; h < this.data.length; h++) a.put(this.data.charCodeAt(h), 8)
                }
            },
            o.prototype = {
                addData: function(a) {
                    this.dataList.push(new u(a)),
                    this.dataCache = null
                },
                isDark: function(a, h) {
                    if (0 > a || this.moduleCount <= a || 0 > h || this.moduleCount <= h) throw Error(a + "," + h);
                    return this.modules[a][h]
                },
                getModuleCount: function() {
                    return this.moduleCount
                },
                make: function() {
                    if (1 > this.typeNumber) {
                        for (var a = 1,
                        a = 1; 40 > a; a++) {
                            for (var g = p.getRSBlocks(a, this.errorCorrectLevel), d = new t, c = 0, e = 0; e < g.length; e++) c += g[e].dataCount;
                            for (e = 0; e < this.dataList.length; e++) g = this.dataList[e],
                            d.put(g.mode, 4),
                            d.put(g.getLength(), h.getLengthInBits(g.mode, a)),
                            g.write(d);
                            if (d.getLengthInBits() <= 8 * c) break
                        }
                        this.typeNumber = a
                    }
                    this.makeImpl(!1, this.getBestMaskPattern())
                },
                makeImpl: function(a, h) {
                    this.moduleCount = 4 * this.typeNumber + 17,
                    this.modules = Array(this.moduleCount);
                    for (var d = 0; d < this.moduleCount; d++) {
                        this.modules[d] = Array(this.moduleCount);
                        for (var g = 0; g < this.moduleCount; g++) this.modules[d][g] = null
                    }
                    this.setupPositionProbePattern(0, 0),
                    this.setupPositionProbePattern(this.moduleCount - 7, 0),
                    this.setupPositionProbePattern(0, this.moduleCount - 7),
                    this.setupPositionAdjustPattern(),
                    this.setupTimingPattern(),
                    this.setupTypeInfo(a, h),
                    7 <= this.typeNumber && this.setupTypeNumber(a),
                    null == this.dataCache && (this.dataCache = o.createData(this.typeNumber, this.errorCorrectLevel, this.dataList)),
                    this.mapData(this.dataCache, h)
                },
                setupPositionProbePattern: function(a, h) {
                    for (var d = -1; 7 >= d; d++) if (! ( - 1 >= a + d || this.moduleCount <= a + d)) for (var g = -1; 7 >= g; g++) - 1 >= h + g || this.moduleCount <= h + g || (this.modules[a + d][h + g] = d >= 0 && 6 >= d && (0 == g || 6 == g) || g >= 0 && 6 >= g && (0 == d || 6 == d) || d >= 2 && 4 >= d && g >= 2 && 4 >= g ? !0 : !1)
                },
                getBestMaskPattern: function() {
                    for (var a = 0,
                    g = 0,
                    d = 0; 8 > d; d++) {
                        this.makeImpl(!0, d);
                        var c = h.getLostPoint(this); (0 == d || a > c) && (a = c, g = d)
                    }
                    return g
                },
                createMovieClip: function(a, h, d) {
                    for (a = a.createEmptyMovieClip(h, d), this.make(), h = 0; h < this.modules.length; h++) for (var d = 1 * h,
                    g = 0; g < this.modules[h].length; g++) {
                        var e = 1 * g;
                        this.modules[h][g] && (a.beginFill(0, 100), a.moveTo(e, d), a.lineTo(e + 1, d), a.lineTo(e + 1, d + 1), a.lineTo(e, d + 1), a.endFill())
                    }
                    return a
                },
                setupTimingPattern: function() {
                    for (var a = 8; a < this.moduleCount - 8; a++) null == this.modules[a][6] && (this.modules[a][6] = 0 == a % 2);
                    for (a = 8; a < this.moduleCount - 8; a++) null == this.modules[6][a] && (this.modules[6][a] = 0 == a % 2)
                },
                setupPositionAdjustPattern: function() {
                    for (var a = h.getPatternPosition(this.typeNumber), g = 0; g < a.length; g++) for (var d = 0; d < a.length; d++) {
                        var c = a[g],
                        e = a[d];
                        if (null == this.modules[c][e]) for (var f = -2; 2 >= f; f++) for (var i = -2; 2 >= i; i++) this.modules[c + f][e + i] = -2 == f || 2 == f || -2 == i || 2 == i || 0 == f && 0 == i ? !0 : !1
                    }
                },
                setupTypeNumber: function(a) {
                    for (var g = h.getBCHTypeNumber(this.typeNumber), d = 0; 18 > d; d++) {
                        var c = !a && 1 == (g >> d & 1);
                        this.modules[Math.floor(d / 3)][d % 3 + this.moduleCount - 8 - 3] = c
                    }
                    for (d = 0; 18 > d; d++) c = !a && 1 == (g >> d & 1),
                    this.modules[d % 3 + this.moduleCount - 8 - 3][Math.floor(d / 3)] = c
                },
                setupTypeInfo: function(a, g) {
                    for (var d = h.getBCHTypeInfo(this.errorCorrectLevel << 3 | g), c = 0; 15 > c; c++) {
                        var e = !a && 1 == (d >> c & 1);
                        6 > c ? this.modules[c][8] = e: 8 > c ? this.modules[c + 1][8] = e: this.modules[this.moduleCount - 15 + c][8] = e
                    }
                    for (c = 0; 15 > c; c++) e = !a && 1 == (d >> c & 1),
                    8 > c ? this.modules[8][this.moduleCount - c - 1] = e: 9 > c ? this.modules[8][15 - c - 1 + 1] = e: this.modules[8][15 - c - 1] = e;
                    this.modules[this.moduleCount - 8][8] = !a
                },
                mapData: function(a, g) {
                    for (var d = -1,
                    c = this.moduleCount - 1,
                    e = 7,
                    f = 0,
                    i = this.moduleCount - 1; i > 0; i -= 2) for (6 == i && i--;;) {
                        for (var C = 0; 2 > C; C++) if (null == this.modules[c][i - C]) {
                            var n = !1;
                            f < a.length && (n = 1 == (a[f] >>> e & 1)),
                            h.getMask(g, c, i - C) && (n = !n),
                            this.modules[c][i - C] = n,
                            e--,
                            -1 == e && (f++, e = 7)
                        }
                        if (c += d, 0 > c || this.moduleCount <= c) {
                            c -= d,
                            d = -d;
                            break
                        }
                    }
                }
            },
            o.PAD0 = 236,
            o.PAD1 = 17,
            o.createData = function(a, g, d) {
                for (var g = p.getRSBlocks(a, g), c = new t, e = 0; e < d.length; e++) {
                    var f = d[e];
                    c.put(f.mode, 4),
                    c.put(f.getLength(), h.getLengthInBits(f.mode, a)),
                    f.write(c)
                }
                for (e = a = 0; e < g.length; e++) a += g[e].dataCount;
                if (c.getLengthInBits() > 8 * a) throw Error("code length overflow. (" + c.getLengthInBits() + ">" + 8 * a + ")");
                for (c.getLengthInBits() + 4 <= 8 * a && c.put(0, 4); 0 != c.getLengthInBits() % 8;) c.putBit(!1);
                for (; ! (c.getLengthInBits() >= 8 * a) && (c.put(o.PAD0, 8), !(c.getLengthInBits() >= 8 * a));) c.put(o.PAD1, 8);
                return o.createBytes(c, g)
            },
            o.createBytes = function(a, g) {
                for (var d = 0,
                c = 0,
                e = 0,
                f = Array(g.length), i = Array(g.length), C = 0; C < g.length; C++) {
                    var n = g[C].dataCount,
                    v = g[C].totalCount - n,
                    c = Math.max(c, n),
                    e = Math.max(e, v);
                    f[C] = Array(n);
                    for (var L = 0; L < f[C].length; L++) f[C][L] = 255 & a.buffer[L + d];
                    for (d += n, L = h.getErrorCorrectPolynomial(v), n = new q(f[C], L.getLength() - 1).mod(L), i[C] = Array(L.getLength() - 1), L = 0; L < i[C].length; L++) v = L + n.getLength() - i[C].length,
                    i[C][L] = v >= 0 ? n.get(v) : 0
                }
                for (L = C = 0; L < g.length; L++) C += g[L].totalCount;
                for (d = Array(C), L = n = 0; c > L; L++) for (C = 0; C < g.length; C++) L < f[C].length && (d[n++] = f[C][L]);
                for (L = 0; e > L; L++) for (C = 0; C < g.length; C++) L < i[C].length && (d[n++] = i[C][L]);
                return d
            },
            s = 4;
            for (var h = {
                PATTERN_POSITION_TABLE: [[], [6, 18], [6, 22], [6, 26], [6, 30], [6, 34], [6, 22, 38], [6, 24, 42], [6, 26, 46], [6, 28, 50], [6, 30, 54], [6, 32, 58], [6, 34, 62], [6, 26, 46, 66], [6, 26, 48, 70], [6, 26, 50, 74], [6, 30, 54, 78], [6, 30, 56, 82], [6, 30, 58, 86], [6, 34, 62, 90], [6, 28, 50, 72, 94], [6, 26, 50, 74, 98], [6, 30, 54, 78, 102], [6, 28, 54, 80, 106], [6, 32, 58, 84, 110], [6, 30, 58, 86, 114], [6, 34, 62, 90, 118], [6, 26, 50, 74, 98, 122], [6, 30, 54, 78, 102, 126], [6, 26, 52, 78, 104, 130], [6, 30, 56, 82, 108, 134], [6, 34, 60, 86, 112, 138], [6, 30, 58, 86, 114, 142], [6, 34, 62, 90, 118, 146], [6, 30, 54, 78, 102, 126, 150], [6, 24, 50, 76, 102, 128, 154], [6, 28, 54, 80, 106, 132, 158], [6, 32, 58, 84, 110, 136, 162], [6, 26, 54, 82, 110, 138, 166], [6, 30, 58, 86, 114, 142, 170]],
                G15: 1335,
                G18: 7973,
                G15_MASK: 21522,
                getBCHTypeInfo: function(a) {
                    for (var g = a << 10; 0 <= h.getBCHDigit(g) - h.getBCHDigit(h.G15);) g ^= h.G15 << h.getBCHDigit(g) - h.getBCHDigit(h.G15);
                    return (a << 10 | g) ^ h.G15_MASK
                },
                getBCHTypeNumber: function(a) {
                    for (var g = a << 12; 0 <= h.getBCHDigit(g) - h.getBCHDigit(h.G18);) g ^= h.G18 << h.getBCHDigit(g) - h.getBCHDigit(h.G18);
                    return a << 12 | g
                },
                getBCHDigit: function(a) {
                    for (var h = 0; 0 != a;) h++,
                    a >>>= 1;
                    return h
                },
                getPatternPosition: function(a) {
                    return h.PATTERN_POSITION_TABLE[a - 1]
                },
                getMask: function(a, h, d) {
                    switch (a) {
                    case 0:
                        return 0 == (h + d) % 2;
                    case 1:
                        return 0 == h % 2;
                    case 2:
                        return 0 == d % 3;
                    case 3:
                        return 0 == (h + d) % 3;
                    case 4:
                        return 0 == (Math.floor(h / 2) + Math.floor(d / 3)) % 2;
                    case 5:
                        return 0 == h * d % 2 + h * d % 3;
                    case 6:
                        return 0 == (h * d % 2 + h * d % 3) % 2;
                    case 7:
                        return 0 == (h * d % 3 + (h + d) % 2) % 2;
                    default:
                        throw Error("bad maskPattern:" + a)
                    }
                },
                getErrorCorrectPolynomial: function(a) {
                    for (var h = new q([1], 0), d = 0; a > d; d++) h = h.multiply(new q([1, l.gexp(d)], 0));
                    return h
                },
                getLengthInBits: function(a, h) {
                    if (h >= 1 && 10 > h) switch (a) {
                    case 1:
                        return 10;
                    case 2:
                        return 9;
                    case s:
                        return 8;
                    case 8:
                        return 8;
                    default:
                        throw Error("mode:" + a)
                    } else if (27 > h) switch (a) {
                    case 1:
                        return 12;
                    case 2:
                        return 11;
                    case s:
                        return 16;
                    case 8:
                        return 10;
                    default:
                        throw Error("mode:" + a)
                    } else {
                        if (! (41 > h)) throw Error("type:" + h);
                        switch (a) {
                        case 1:
                            return 14;
                        case 2:
                            return 13;
                        case s:
                            return 16;
                        case 8:
                            return 12;
                        default:
                            throw Error("mode:" + a)
                        }
                    }
                },
                getLostPoint: function(a) {
                    for (var h = a.getModuleCount(), d = 0, g = 0; h > g; g++) for (var e = 0; h > e; e++) {
                        for (var f = 0,
                        i = a.isDark(g, e), c = -1; 1 >= c; c++) if (! (0 > g + c || g + c >= h)) for (var C = -1; 1 >= C; C++) 0 > e + C || e + C >= h || 0 == c && 0 == C || i == a.isDark(g + c, e + C) && f++;
                        f > 5 && (d += 3 + f - 5)
                    }
                    for (g = 0; h - 1 > g; g++) for (e = 0; h - 1 > e; e++) f = 0,
                    a.isDark(g, e) && f++,
                    a.isDark(g + 1, e) && f++,
                    a.isDark(g, e + 1) && f++,
                    a.isDark(g + 1, e + 1) && f++,
                    (0 == f || 4 == f) && (d += 3);
                    for (g = 0; h > g; g++) for (e = 0; h - 6 > e; e++) a.isDark(g, e) && !a.isDark(g, e + 1) && a.isDark(g, e + 2) && a.isDark(g, e + 3) && a.isDark(g, e + 4) && !a.isDark(g, e + 5) && a.isDark(g, e + 6) && (d += 40);
                    for (e = 0; h > e; e++) for (g = 0; h - 6 > g; g++) a.isDark(g, e) && !a.isDark(g + 1, e) && a.isDark(g + 2, e) && a.isDark(g + 3, e) && a.isDark(g + 4, e) && !a.isDark(g + 5, e) && a.isDark(g + 6, e) && (d += 40);
                    for (e = f = 0; h > e; e++) for (g = 0; h > g; g++) a.isDark(g, e) && f++;
                    return a = Math.abs(100 * f / h / h - 50) / 5,
                    d + 10 * a
                }
            },
            l = {
                glog: function(a) {
                    if (1 > a) throw Error("glog(" + a + ")");
                    return l.LOG_TABLE[a]
                },
                gexp: function(a) {
                    for (; 0 > a;) a += 255;
                    for (; a >= 256;) a -= 255;
                    return l.EXP_TABLE[a]
                },
                EXP_TABLE: Array(256),
                LOG_TABLE: Array(256)
            },
            m = 0; 8 > m; m++) l.EXP_TABLE[m] = 1 << m;
            for (m = 8; 256 > m; m++) l.EXP_TABLE[m] = l.EXP_TABLE[m - 4] ^ l.EXP_TABLE[m - 5] ^ l.EXP_TABLE[m - 6] ^ l.EXP_TABLE[m - 8];
            for (m = 0; 255 > m; m++) l.LOG_TABLE[l.EXP_TABLE[m]] = m;
            return q.prototype = {
                get: function(a) {
                    return this.num[a]
                },
                getLength: function() {
                    return this.num.length
                },
                multiply: function(a) {
                    for (var h = Array(this.getLength() + a.getLength() - 1), d = 0; d < this.getLength(); d++) for (var g = 0; g < a.getLength(); g++) h[d + g] ^= l.gexp(l.glog(this.get(d)) + l.glog(a.get(g)));
                    return new q(h, 0)
                },
                mod: function(a) {
                    if (0 > this.getLength() - a.getLength()) return this;
                    for (var h = l.glog(this.get(0)) - l.glog(a.get(0)), d = Array(this.getLength()), g = 0; g < this.getLength(); g++) d[g] = this.get(g);
                    for (g = 0; g < a.getLength(); g++) d[g] ^= l.gexp(l.glog(a.get(g)) + h);
                    return new q(d, 0).mod(a)
                }
            },
            p.RS_BLOCK_TABLE = [[1, 26, 19], [1, 26, 16], [1, 26, 13], [1, 26, 9], [1, 44, 34], [1, 44, 28], [1, 44, 22], [1, 44, 16], [1, 70, 55], [1, 70, 44], [2, 35, 17], [2, 35, 13], [1, 100, 80], [2, 50, 32], [2, 50, 24], [4, 25, 9], [1, 134, 108], [2, 67, 43], [2, 33, 15, 2, 34, 16], [2, 33, 11, 2, 34, 12], [2, 86, 68], [4, 43, 27], [4, 43, 19], [4, 43, 15], [2, 98, 78], [4, 49, 31], [2, 32, 14, 4, 33, 15], [4, 39, 13, 1, 40, 14], [2, 121, 97], [2, 60, 38, 2, 61, 39], [4, 40, 18, 2, 41, 19], [4, 40, 14, 2, 41, 15], [2, 146, 116], [3, 58, 36, 2, 59, 37], [4, 36, 16, 4, 37, 17], [4, 36, 12, 4, 37, 13], [2, 86, 68, 2, 87, 69], [4, 69, 43, 1, 70, 44], [6, 43, 19, 2, 44, 20], [6, 43, 15, 2, 44, 16], [4, 101, 81], [1, 80, 50, 4, 81, 51], [4, 50, 22, 4, 51, 23], [3, 36, 12, 8, 37, 13], [2, 116, 92, 2, 117, 93], [6, 58, 36, 2, 59, 37], [4, 46, 20, 6, 47, 21], [7, 42, 14, 4, 43, 15], [4, 133, 107], [8, 59, 37, 1, 60, 38], [8, 44, 20, 4, 45, 21], [12, 33, 11, 4, 34, 12], [3, 145, 115, 1, 146, 116], [4, 64, 40, 5, 65, 41], [11, 36, 16, 5, 37, 17], [11, 36, 12, 5, 37, 13], [5, 109, 87, 1, 110, 88], [5, 65, 41, 5, 66, 42], [5, 54, 24, 7, 55, 25], [11, 36, 12], [5, 122, 98, 1, 123, 99], [7, 73, 45, 3, 74, 46], [15, 43, 19, 2, 44, 20], [3, 45, 15, 13, 46, 16], [1, 135, 107, 5, 136, 108], [10, 74, 46, 1, 75, 47], [1, 50, 22, 15, 51, 23], [2, 42, 14, 17, 43, 15], [5, 150, 120, 1, 151, 121], [9, 69, 43, 4, 70, 44], [17, 50, 22, 1, 51, 23], [2, 42, 14, 19, 43, 15], [3, 141, 113, 4, 142, 114], [3, 70, 44, 11, 71, 45], [17, 47, 21, 4, 48, 22], [9, 39, 13, 16, 40, 14], [3, 135, 107, 5, 136, 108], [3, 67, 41, 13, 68, 42], [15, 54, 24, 5, 55, 25], [15, 43, 15, 10, 44, 16], [4, 144, 116, 4, 145, 117], [17, 68, 42], [17, 50, 22, 6, 51, 23], [19, 46, 16, 6, 47, 17], [2, 139, 111, 7, 140, 112], [17, 74, 46], [7, 54, 24, 16, 55, 25], [34, 37, 13], [4, 151, 121, 5, 152, 122], [4, 75, 47, 14, 76, 48], [11, 54, 24, 14, 55, 25], [16, 45, 15, 14, 46, 16], [6, 147, 117, 4, 148, 118], [6, 73, 45, 14, 74, 46], [11, 54, 24, 16, 55, 25], [30, 46, 16, 2, 47, 17], [8, 132, 106, 4, 133, 107], [8, 75, 47, 13, 76, 48], [7, 54, 24, 22, 55, 25], [22, 45, 15, 13, 46, 16], [10, 142, 114, 2, 143, 115], [19, 74, 46, 4, 75, 47], [28, 50, 22, 6, 51, 23], [33, 46, 16, 4, 47, 17], [8, 152, 122, 4, 153, 123], [22, 73, 45, 3, 74, 46], [8, 53, 23, 26, 54, 24], [12, 45, 15, 28, 46, 16], [3, 147, 117, 10, 148, 118], [3, 73, 45, 23, 74, 46], [4, 54, 24, 31, 55, 25], [11, 45, 15, 31, 46, 16], [7, 146, 116, 7, 147, 117], [21, 73, 45, 7, 74, 46], [1, 53, 23, 37, 54, 24], [19, 45, 15, 26, 46, 16], [5, 145, 115, 10, 146, 116], [19, 75, 47, 10, 76, 48], [15, 54, 24, 25, 55, 25], [23, 45, 15, 25, 46, 16], [13, 145, 115, 3, 146, 116], [2, 74, 46, 29, 75, 47], [42, 54, 24, 1, 55, 25], [23, 45, 15, 28, 46, 16], [17, 145, 115], [10, 74, 46, 23, 75, 47], [10, 54, 24, 35, 55, 25], [19, 45, 15, 35, 46, 16], [17, 145, 115, 1, 146, 116], [14, 74, 46, 21, 75, 47], [29, 54, 24, 19, 55, 25], [11, 45, 15, 46, 46, 16], [13, 145, 115, 6, 146, 116], [14, 74, 46, 23, 75, 47], [44, 54, 24, 7, 55, 25], [59, 46, 16, 1, 47, 17], [12, 151, 121, 7, 152, 122], [12, 75, 47, 26, 76, 48], [39, 54, 24, 14, 55, 25], [22, 45, 15, 41, 46, 16], [6, 151, 121, 14, 152, 122], [6, 75, 47, 34, 76, 48], [46, 54, 24, 10, 55, 25], [2, 45, 15, 64, 46, 16], [17, 152, 122, 4, 153, 123], [29, 74, 46, 14, 75, 47], [49, 54, 24, 10, 55, 25], [24, 45, 15, 46, 46, 16], [4, 152, 122, 18, 153, 123], [13, 74, 46, 32, 75, 47], [48, 54, 24, 14, 55, 25], [42, 45, 15, 32, 46, 16], [20, 147, 117, 4, 148, 118], [40, 75, 47, 7, 76, 48], [43, 54, 24, 22, 55, 25], [10, 45, 15, 67, 46, 16], [19, 148, 118, 6, 149, 119], [18, 75, 47, 31, 76, 48], [34, 54, 24, 34, 55, 25], [20, 45, 15, 61, 46, 16]],
            p.getRSBlocks = function(a, h) {
                var d = p.getRsBlockTable(a, h);
                if (void 0 == d) throw Error("bad rs block @ typeNumber:" + a + "/errorCorrectLevel:" + h);
                for (var g = d.length / 3,
                e = [], f = 0; g > f; f++) for (var c = d[3 * f + 0], C = d[3 * f + 1], v = d[3 * f + 2], l = 0; c > l; l++) e.push(new p(C, v));
                return e
            },
            p.getRsBlockTable = function(a, h) {
                switch (h) {
                case 1:
                    return p.RS_BLOCK_TABLE[4 * (a - 1) + 0];
                case 0:
                    return p.RS_BLOCK_TABLE[4 * (a - 1) + 1];
                case 3:
                    return p.RS_BLOCK_TABLE[4 * (a - 1) + 2];
                case 2:
                    return p.RS_BLOCK_TABLE[4 * (a - 1) + 3]
                }
            },
            t.prototype = {
                get: function(a) {
                    return 1 == (this.buffer[Math.floor(a / 8)] >>> 7 - a % 8 & 1)
                },
                put: function(a, h) {
                    for (var d = 0; h > d; d++) this.putBit(1 == (a >>> h - d - 1 & 1))
                },
                getLengthInBits: function() {
                    return this.length
                },
                putBit: function(a) {
                    var h = Math.floor(this.length / 8);
                    this.buffer.length <= h && this.buffer.push(0),
                    a && (this.buffer[h] |= 128 >>> this.length % 8),
                    this.length++
                }
            },
            "string" == typeof a && (a = {
                text: a
            }),
            a = r.extend({},
            {
                render: "canvas",
                width: 256,
                height: 256,
                typeNumber: -1,
                correctLevel: 2,
                background: "#ffffff",
                foreground: "#000000"
            },
            a),
            this.each(function() {
                var h;
                if ("canvas" == a.render) {
                    h = new o(a.typeNumber, a.correctLevel),
                    h.addData(a.text),
                    h.make();
                    var g = document.createElement("canvas");
                    g.width = a.width,
                    g.height = a.height;
                    for (var d = g.getContext("2d"), c = a.width / h.getModuleCount(), e = a.height / h.getModuleCount(), f = 0; f < h.getModuleCount(); f++) for (var i = 0; i < h.getModuleCount(); i++) {
                        d.fillStyle = h.isDark(f, i) ? a.foreground: a.background;
                        var C = Math.ceil((i + 1) * c) - Math.floor(i * c),
                        v = Math.ceil((f + 1) * c) - Math.floor(f * c);
                        d.fillRect(Math.round(i * c), Math.round(f * e), C, v)
                    }
                } else for (h = new o(a.typeNumber, a.correctLevel), h.addData(a.text), h.make(), g = r("<table></table>").css("width", a.width + "px").css("height", a.height + "px").css("border", "0px").css("border-collapse", "collapse").css("background-color", a.background), d = a.width / h.getModuleCount(), c = a.height / h.getModuleCount(), e = 0; e < h.getModuleCount(); e++) for (f = r("<tr></tr>").css("height", c + "px").appendTo(g), i = 0; i < h.getModuleCount(); i++) r("<td></td>").css("width", d + "px").css("background-color", h.isDark(e, i) ? a.foreground: a.background).appendTo(f);
                h = g,
                jQuery(h).appendTo(this)
            })
        }
    } (jQuery)
});
/*!common/widgets/passport/modules/wechat-qrcode/main.js*/
;
define("common/widgets/passport/modules/wechat-qrcode/main", ["require", "exports", "module", "common/widgets/passport/dep/socketio-java/socket.other", "common/widgets/passport/dep/socketio-java/moment.min", "common/widgets/passport/dep/jquery.qrcode/jquery.qrcode.min"],
function(require, exports, module) {
    function c(c) {
        var a = c.split("?") || [],
        h = {
            url: a[0]
        };
        if (a.length > 1) for (var g = a[1].split("&"), i = 0, l = g.length; l > i; i++) {
            var w = g[i].split("=");
            h[w[0]] = w[1]
        }
        return h
    }
    function a(c) {
        var a = this.$wrapper = $(c.wrapper);
        this.isLogin = c.isLogin,
        this.qrCodeCanvas = a.find(".qrCodeCanvas"),
        this.qrCode = a.find(".qrCode"),
        this.$scanSuccess = a.find(".scan-success"),
        this.$scanContent = a.find(".scan-content"),
        this.authIdUrl = GLOBAL_DOMAIN.pctx + "/login/auth_id.json",
        this.qrCodeText = {
            login: function(c) {
                return "https://weapp.lagou.com/qr/c/login?authId=" + c
            },
            register: function(c, a) {
                var a = a.toLowerCase();
                return "https://weapp.lagou.com/qr/" + a + "/register?authId=" + c
            }
        },
        this.minaCodeText = {
            login: function(c) {
                return "https://weapp.lagou.com/api/weapp-code/pc-login-image?width=170&authId=" + c + "&isBSide=false&isLogin=true&lineColor=rgb(0,179,138)"
            },
            register: function(c, a) {
                return "https://weapp.lagou.com/api/weapp-code/pc-login-image?width=170&lineColor=rgb(0,179,138)&authId=" + c + "&isBSide=" + ("B" === a ? !0 : !1)
            }
        },
        this.succCode = 1,
        this.expireTimeId,
        this.socketInfo,
        this.socketUrl = "https://sm.lagou.com/scanQrcode",
        this.registerType = "C"
    }
    var h = require("common/widgets/passport/dep/socketio-java/socket.other");
    require("common/widgets/passport/dep/socketio-java/moment.min"),
    require("common/widgets/passport/dep/jquery.qrcode/jquery.qrcode.min"),
    a.prototype.openQrCode = function(c) {
        var a = this;
        c && (a.registerType = c.registerType),
        a.closeQrCode(),
        a.getAuthId()
    },
    a.prototype.closeQrCode = function() {
        var c = this,
        a = c.expireTimeId,
        h = c.socketInfo;
        a && clearTimeout(a),
        h && h.close()
    },
    a.prototype.getQrCodeText = function(c) {
        var a = this,
        h = a.registerType;
        return a.isLogin ? a.qrCodeText.login(c) : a.qrCodeText.register(c, h)
    },
    a.prototype.getMinaCodeText = function(c) {
        var a = this,
        h = a.registerType;
        return a.isLogin ? a.minaCodeText.login(c) : a.minaCodeText.register(c, h)
    },
    a.prototype.getAuthId = function() {
        var c = this,
        a = c.succCode,
        h = c.qrCode,
        g = c.qrCodeCanvas;
        c.expireTimeId && (clearTimeout(c.expireTimeId), c.socketInfo.close(), c.$scanSuccess.hide(), c.$scanContent.css({
            opacity: 1
        })),
        $.ajax({
            url: GLOBAL_DOMAIN.pctx + "/login/auth_id.json",
            dataType: "jsonp",
            jsonp: "jsoncallback"
        }).done(function(w) {
            if (w.state === a) {
                c.getSocket();
                var C = w.content.data,
                v = 1e3;
                c.expireTimeId = setTimeout(function() {
                    clearTimeout(c.expireTimeId),
                    c.getAuthId(),
                    c.$scanSuccess.hide(),
                    c.$scanContent.css({
                        opacity: 1
                    })
                },
                C.expireSeconds * v)
            }
            if (C.isQRCode) {
                h.hide();
                var T = c.getQrCodeText(C.authId);
                g.html(""),
                g.qrcode({
                    render: "canvas",
                    text: T,
                    width: 180,
                    height: 180,
                    correctLevel: 3,
                    foreground: "#000000"
                }),
                g.attr("title", T),
                g.show()
            } else {
                var y = c.getMinaCodeText(C.authId);
                g.hide(),
                h.attr("src", y),
                h.show()
            }
        })
    },
    a.prototype.getSocket = function() {
        var a = this,
        g = a.socketUrl,
        w = a.$scanSuccess,
        C = a.$scanContent,
        v = a.expireTimeId,
        T = h.connect(g, {
            path: "/push",
            "force new connection": !0,
            reconnection: !0,
            reconnectionDelay: 2e3,
            reconnectionDelayMax: 5e3,
            reconnectionAttempts: "Infinity",
            timeout: 1e4,
            transports: ["polling", "websocket"],
            query: {
                uri: window.location.pathname
            }
        });
        T.on("scanQrcode",
        function(h) {
            var g = JSON.parse(h),
            v = a.succCode,
            T = g.content;
            if (g.type === v) w.show(),
            C.css({
                opacity: 0
            });
            else if (0 === g.type) if (/callback/.test(T)) window.location.href = T;
            else {
                var y = window.location.href;
                if (y = c(y), y.service) {
                    var I = y.service.split(".com");
                    window.location.href = /lagou/.test(I[0]) ? T + "&callback=" + y.service: T + "&callback=" + encodeURIComponent(window.location.href)
                } else window.location.href = T + "&callback=" + encodeURIComponent(window.location.href)
            }
        }),
        T.on("connect_error",
        function() {
            clearTimeout(v),
            w.hide(),
            C.css({
                opacity: 1
            }),
            T.close()
        }),
        a.socketInfo = T
    },
    module.exports = a
});
/*!common/components/modal/modal.js*/
;
define("common/components/modal/modal", ["require", "exports", "module"],
function() { +
    function(a) {
        "use strict";
        function h(h, b) {
            return this.each(function() {
                var g = a(this),
                $ = g.data("bs.modal"),
                y = a.extend({},
                c.DEFAULTS, g.data(), "object" == typeof h && h);
                $ || g.data("bs.modal", $ = new c(this, y)),
                "string" == typeof h ? $[h](b) : y.show && $.show(b)
            })
        }
        var c = function(h, c) {
            this.options = c,
            this.$body = a(document.body),
            this.$element = a(h),
            this.$dialog = this.$element.find(".modal-dialog"),
            this.$backdrop = null,
            this.isShown = null,
            this.originalBodyPad = null,
            this.scrollbarWidth = 0,
            this.ignoreBackdropClick = !1,
            this.options.remote && this.$element.find(".modal-content").load(this.options.remote, a.proxy(function() {
                this.$element.trigger("loaded.bs.modal")
            },
            this))
        };
        c.VERSION = "3.3.7",
        c.TRANSITION_DURATION = 300,
        c.BACKDROP_TRANSITION_DURATION = 150,
        c.DEFAULTS = {
            backdrop: !0,
            keyboard: !0,
            show: !0
        },
        c.prototype.toggle = function(a) {
            return this.isShown ? this.hide() : this.show(a)
        },
        c.prototype.show = function(h) {
            var b = this,
            e = a.Event("show.bs.modal", {
                relatedTarget: h
            });
            this.$element.trigger(e),
            this.isShown || e.isDefaultPrevented() || (this.isShown = !0, this.checkScrollbar(), this.setScrollbar(), this.$body.addClass("modal-open"), this.escape(), this.resize(), this.$element.on("click.dismiss.bs.modal", "[data-dismiss="modal"]", a.proxy(this.hide, this)), this.$dialog.on("mousedown.dismiss.bs.modal",
            function() {
                b.$element.one("mouseup.dismiss.bs.modal",
                function(e) {
                    a(e.target).is(b.$element) && (b.ignoreBackdropClick = !0)
                })
            }), this.backdrop(function() {
                var g = a.support.transition && b.$element.hasClass("fade");
                b.$element.parent().length || b.$element.appendTo(b.$body),
                b.$element.show().scrollTop(0),
                b.adjustDialog(),
                g && b.$element[0].offsetWidth,
                b.$element.addClass("in"),
                b.enforceFocus();
                var e = a.Event("shown.bs.modal", {
                    relatedTarget: h
                });
                g ? b.$dialog.one("bsTransitionEnd",
                function() {
                    b.$element.trigger("focus").trigger(e)
                }).emulateTransitionEnd(c.TRANSITION_DURATION) : b.$element.trigger("focus").trigger(e)
            }))
        },
        c.prototype.hide = function(e) {
            e && e.preventDefault(),
            e = a.Event("hide.bs.modal"),
            this.$element.trigger(e),
            this.isShown && !e.isDefaultPrevented() && (this.isShown = !1, this.escape(), this.resize(), a(document).off("focusin.bs.modal"), this.$element.removeClass("in").off("click.dismiss.bs.modal").off("mouseup.dismiss.bs.modal"), this.$dialog.off("mousedown.dismiss.bs.modal"), a.support.transition && this.$element.hasClass("fade") ? this.$element.one("bsTransitionEnd", a.proxy(this.hideModal, this)).emulateTransitionEnd(c.TRANSITION_DURATION) : this.hideModal())
        },
        c.prototype.enforceFocus = function() {
            a(document).off("focusin.bs.modal").on("focusin.bs.modal", a.proxy(function(e) {
                document === e.target || this.$element[0] === e.target || this.$element.has(e.target).length || this.$element.trigger("focus")
            },
            this))
        },
        c.prototype.escape = function() {
            this.isShown && this.options.keyboard ? this.$element.on("keydown.dismiss.bs.modal", a.proxy(function(e) {
                27 == e.which && this.hide()
            },
            this)) : this.isShown || this.$element.off("keydown.dismiss.bs.modal")
        },
        c.prototype.resize = function() {
            this.isShown ? a(window).on("resize.bs.modal", a.proxy(this.handleUpdate, this)) : a(window).off("resize.bs.modal")
        },
        c.prototype.hideModal = function() {
            var a = this;
            this.$element.hide(),
            this.backdrop(function() {
                a.$body.removeClass("modal-open"),
                a.resetAdjustments(),
                a.resetScrollbar(),
                a.$element.trigger("hidden.bs.modal")
            })
        },
        c.prototype.removeBackdrop = function() {
            this.$backdrop && this.$backdrop.remove(),
            this.$backdrop = null
        },
        c.prototype.backdrop = function(h) {
            var b = this,
            g = this.$element.hasClass("fade") ? "fade": "";
            if (this.isShown && this.options.backdrop) {
                var $ = a.support.transition && g;
                if (this.$backdrop = a(document.createElement("div")).addClass("modal-backdrop " + g).appendTo(this.$element), this.$backdrop.on("click.dismiss.bs.modal", a.proxy(function(e) {
                    return this.ignoreBackdropClick ? void(this.ignoreBackdropClick = !1) : void(e.target === e.currentTarget && ("static" == this.options.backdrop ? this.$element[0].focus() : this.hide()))
                },
                this)), $ && this.$backdrop[0].offsetWidth, this.$backdrop.addClass("in"), !h) return;
                $ ? this.$backdrop.one("bsTransitionEnd", h).emulateTransitionEnd(c.BACKDROP_TRANSITION_DURATION) : h()
            } else if (!this.isShown && this.$backdrop) {
                this.$backdrop.removeClass("in");
                var y = function() {
                    b.removeBackdrop(),
                    h && h()
                };
                a.support.transition && this.$element.hasClass("fade") ? this.$backdrop.one("bsTransitionEnd", y).emulateTransitionEnd(c.BACKDROP_TRANSITION_DURATION) : y()
            } else h && h()
        },
        c.prototype.handleUpdate = function() {
            this.adjustDialog()
        },
        c.prototype.adjustDialog = function() {
            var a = this.$element[0].scrollHeight > document.documentElement.clientHeight;
            this.$element.css({
                paddingLeft: !this.bodyIsOverflowing && a ? this.scrollbarWidth: "",
                paddingRight: this.bodyIsOverflowing && !a ? this.scrollbarWidth: ""
            })
        },
        c.prototype.resetAdjustments = function() {
            this.$element.css({
                paddingLeft: "",
                paddingRight: ""
            })
        },
        c.prototype.checkScrollbar = function() {
            var a = window.innerWidth;
            if (!a) {
                var h = document.documentElement.getBoundingClientRect();
                a = h.right - Math.abs(h.left)
            }
            this.bodyIsOverflowing = document.body.clientWidth < a,
            this.scrollbarWidth = this.measureScrollbar()
        },
        c.prototype.setScrollbar = function() {
            var a = parseInt(this.$body.css("padding-right") || 0, 10);
            this.originalBodyPad = document.body.style.paddingRight || "",
            this.bodyIsOverflowing && this.$body.css("padding-right", a + this.scrollbarWidth)
        },
        c.prototype.resetScrollbar = function() {
            this.$body.css("padding-right", this.originalBodyPad)
        },
        c.prototype.measureScrollbar = function() {
            var a = document.createElement("div");
            a.className = "modal-scrollbar-measure",
            this.$body.append(a);
            var h = a.offsetWidth - a.clientWidth;
            return this.$body[0].removeChild(a),
            h
        };
        var b = a.fn.modal;
        a.fn.modal = h,
        a.fn.modal.Constructor = c,
        a.fn.modal.noConflict = function() {
            return a.fn.modal = b,
            this
        },
        a(document).on("click.bs.modal.data-api", "[data-toggle="modal"]",
        function(e) {
            var c = a(this),
            b = c.attr("href"),
            g = a(c.attr("data-target") || b && b.replace(/.*(?=#[^\s]+$)/, "")),
            $ = g.data("bs.modal") ? "toggle": a.extend({
                remote: !/#/.test(b) && b
            },
            g.data(), c.data());
            c.is("a") && e.preventDefault(),
            g.one("show.bs.modal",
            function(a) {
                a.isDefaultPrevented() || g.one("hidden.bs.modal",
                function() {
                    c.is(":visible") && c.trigger("focus")
                })
            }),
            h.call(g, $, this)
        })
    } (jQuery)
});
/*!common/widgets/passport/common/js/lagou.js*/
;
define("common/widgets/passport/common/js/lagou", ["require", "exports", "module"],
function(require, exports, module) {
    var lg = window.lg || {};
    Array.prototype.indexOf || (Array.prototype.indexOf = function(a) {
        var g = this.length >>> 0,
        h = Number(arguments[1]) || 0;
        for (h = 0 > h ? Math.ceil(h) : Math.floor(h), 0 > h && (h += g); g > h; h++) if (h in this && this[h] === a) return h;
        return - 1
    }),
    String.prototype.trim || (String.prototype.trim = function() {
        return this.replace(/(^\s*)|(\s*$)/g, "")
    },
    String.prototype.ltrim = function() {
        return this.replace(/(^\s*)/g, "")
    },
    String.prototype.rtrim = function() {
        return this.replace(/(\s*$)/g, "")
    }),
    lg.Event = lg.Event || {},
    lg.Event._events = {},
    lg.Event.on = function(a, g, h) {
        return this._events[a] = this._events[a] || [],
        this._events[a].push({
            data: g,
            func: h
        }),
        this
    },
    lg.Event.un = function(a) {
        var g = this._events;
        if (0 === arguments.length) return this._events = {},
        this;
        var h = g[a];
        if (!h) return this;
        if (1 === arguments.length) return delete g[a],
        this;
        for (var c, i = 0; i < h.length; i++) if (c = h[i], c === listener || c.listener === listener) {
            h.splice(i, 1);
            break
        }
        return this
    },
    lg.Event.exec = function(a) {
        var g = this._events,
        h = g[a],
        c = Array.prototype.slice.call(arguments, 1);
        if (h) {
            h = h.slice(0);
            for (var i = 0,
            v = h.length; v > i; i++) h[i].apply(this, c)
        }
        return this
    },
    lg.Cache = lg.Cache || {},
    lg.Cache.Views = lg.Cache.Views || {},
    lg.Utils = lg.Utils || {},
    lg.Utils.isNullObject = function(a) {
        if ("object" == typeof a && !(a instanceof Array)) {
            var g = !1;
            for (var h in a) {
                g = !0;
                break
            }
            return g
        }
    },
    lg.Widgets = lg.Widgets || {},
    lg.Widgets.BaseControl = function(a) {
        if (this._name = "", this._option = {},
        this.Event = lg.Event, this._data = {},
        this._value = "", this._isDirty = !1, this._isValueField = !0, this._data.valid = this._data.valid || {},
        this._data.valid.validResult = {},
        this._data.valid._map = {
            require: {
                mode: "require",
                isUse: !1,
                status: !1,
                data: "",
                message: "必填",
                level: "3",
                trigger: []
            },
            re_pwd: {
                mode: "repeat-password",
                isUse: !1,
                status: !1,
                data: "",
                message: "",
                level: "2",
                trigger: []
            },
            min_len: {
                mode: "min-length",
                isUse: !1,
                status: !1,
                data: "",
                message: "最小长度",
                level: "1",
                trigger: []
            },
            max_len: {
                mode: "max-length",
                isUse: !1,
                status: !1,
                data: "",
                message: "最大长度",
                level: "1",
                trigger: []
            },
            pattern: {
                mode: "pattern",
                isUse: !1,
                status: !1,
                data: "",
                message: "",
                level: "2",
                trigger: []
            }
        },
        $.extend(this._option, a), this._option.validRules) for (var i = 0,
        g = this._option.validRules.length; g > i; i++) {
            var h = this._option.validRules[i];
            this._data.valid._map[h.mode] ? (this._data.valid._map[h.mode].isUse = !0, this._data.valid._map[h.mode].data = h.data, this._data.valid._map[h.mode].message = h.message, this._data.valid._map[h.mode].level = h.level || this._data.valid._map[h.mode].level) : this._data.valid._map[h.mode] = {
                mode: h.mode,
                isUse: !0,
                status: !1,
                data: h.data,
                message: h.message,
                level: 0
            },
            h.trigger ? this._data.valid._map[h.mode].trigger = h.trigger.split(",") : this._data.valid._map[h.mode].trigger.push("blur")
        }
        this._selector = "[data-view="" + this._option.parentName + ""] [data-propertyname="" + this._option.name + ""]",
        this._element = "string" == typeof this._option.name ? $(this._selector) : this._option.name,
        "function" == typeof this.init ? this.init() : ""
    },
    lg.Widgets.BaseControl.prototype.getIsValueField = function() {
        return this._isValueField
    },
    lg.Widgets.BaseControl.prototype.setIsValueField = function(a) {
        var g = !1;
        a && (g = !0),
        this._isValueField = g
    },
    lg.Widgets.BaseControl.prototype.getName = function() {
        return this._option.name
    },
    lg.Widgets.BaseControl.prototype.getElement = function() {
        return this._element
    },
    lg.Widgets.BaseControl.prototype.BaseInit = function(a) {
        this.setData(a);
        var g = this,
        h = !0;
        this._option.isFocusShow || this.getElement().find("input[type="text"],input[type="password"],input[type="checkbox"],input.btn_outline").on("focus",
        function() {
            g.setValidMessage(),
            g.getElement().addClass("focus")
        }),
        "undefined" == typeof this._option.isVisible ? h: h = !1,
        this.setVisible(h),
        this.getElement().find("input[type="text"],input[type="password"]").on("blur", {
            control: this
        },
        function(e) {
            var a = e.data.control;
            a.getElement().removeClass("focus")
        }),
        this.getElement().find("input[type="text"],input[type="password"]").on("blur keydown change keyup", {
            control: this
        },
        function(e) {
            var a = e.data.control;
            "keydown" == e.type && (a._isDirty = !0);
            var g = a.getValue(),
            h = a.getIsValid(g, e.type);
            return a._isDirty && a.getSelfIsValided() && ("keyup" == e.type || "change" == e.type) ? a._option.keyup && (a.execValid(a.getValue()), a._option.keyup.call(this, {
                control: a,
                isValidat: !0,
                parent: lg.Cache.Views[a._option.parentName],
                linkFor: lg.Cache.Views[a._option.parentName].field[a._option.linkFor]
            })) : !a._isDirty || a.getSelfIsValided() || "keyup" != e.type && "change" != e.type || a._option.keyup && (a.execValid(a.getValue()), a._option.keyup.call(this, {
                control: a,
                isValidat: !1,
                parent: lg.Cache.Views[a._option.parentName],
                linkFor: lg.Cache.Views[a._option.parentName].field[a._option.linkFor]
            })),
            lg.Utils.isNullObject(h) ? void a.setValidMessage(h) : void a.setValidMessage()
        })
    },
    lg.Widgets.BaseControl.prototype.showMessage = function(a) {
        this.getElement().find("[data-valid-message]").length ? "": this.getElement().append("<span data-valid-message class="input_tips"></span>"); {
            var g = this.getElement().find("[data-valid-message]");
            g.html()
        }
        if (lg.Utils.isNullObject(a)) {
            g.empty();
            g.html(a.message),
            g.show(),
            this.getElement().find("input[type="text"]").addClass("input_warning"),
            this.getElement().find("input[type="password"]").addClass("input_warning")
        } else g.remove(),
        this.getElement().find("input[type="text"]").removeClass("input_warning"),
        this.getElement().find("input[type="password"]").removeClass("input_warning")
    },
    lg.Widgets.BaseControl.prototype.setValidMessage = function(a, g) {
        if (this._option.forbidAddMessageBySelf) if ("CollectData" == g) {
            this.getElement().find("[data-valid-message]").length ? "": this.getElement().append("<span data-valid-message class="input_tips"></span>");
            var h = this.getElement().find("[data-valid-message]")
        } else {
            var h = this.getElement().find("[data-valid-message]");
            if (!h && h.length > 0) return
        } else {
            this.getElement().find("[data-valid-message]").length ? "": this.getElement().append("<span data-valid-message class="input_tips"></span>");
            var h = this.getElement().find("[data-valid-message]")
        }
        h.html();
        if (lg.Utils.isNullObject(a || {})) {
            h.empty();
            var c = "",
            v = 0;
            for (var _ in a)"undefined" != typeof a[_].level ? v = v < a[_].level ? a[_].level: v: "";
            for (var _ in a)"undefined" != typeof a[_].level && v == a[_].level && (c = a[_].message);
            h.html(c),
            h.show(),
            this.getElement().find("input[type="text"]").addClass("input_warning"),
            this.getElement().find("input[type="password"]").addClass("input_warning")
        } else h.remove(),
        this.getElement().find("input[type="text"]").removeClass("input_warning"),
        this.getElement().find("input[type="password"]").removeClass("input_warning")
    },
    lg.Widgets.BaseControl.prototype.setData = function(a) {
        for (var g in a) this["set" + g] = a[g]
    },
    lg.Widgets.BaseControl.prototype.setClear = function() {
        this.getElement().find("input.input_warning").removeClass("input_warning"),
        this.getElement().find("[data-valid-message]").remove(),
        this.getElement().find("input[type="text"],input[type="password"]").val(""),
        this._isDirty = !1,
        this.getElement().find("input[type="text"],input[type="password"]").blur()
    },
    lg.Widgets.BaseControl.prototype.getIsReadOnly = function() {
        return this.getElement().attr("readonly") ? !0 : !1
    },
    lg.Widgets.BaseControl.prototype.setReadOnly = function(a) {
        var g = !1;
        a && (g = !0),
        g ? this.getElement().attr("readonly", g) : this.getElement().removeAttr("readonly")
    },
    lg.Widgets.BaseControl.prototype.getIsDisabled = function() {
        return this.getElement().attr("disabled") ? !0 : !1
    },
    lg.Widgets.BaseControl.prototype.setFocus = function(a) {
        var g = !1;
        a && (g = !0, this.getElement().find("input[type ="text"]").focus())
    },
    lg.Widgets.BaseControl.prototype.setDisable = function(a) {
        var g = !1;
        a && (g = !0),
        g ? this.getElement().attr("disabled", g) : this.getElement().removeAttr("disabled"),
        g ? (this.getElement().attr("disabled", g), this.getElement().find("input[type="button"]").attr("disabled", g)) : (this.getElement().removeAttr("disabled"), this.getElement().find("input[type="button"]").removeAttr("disabled"))
    },
    lg.Widgets.BaseControl.prototype.getIsVisible = function() {
        return "none" != this.getElement().css("display") ? !0 : !1
    },
    lg.Widgets.BaseControl.prototype.setVisible = function(a) {
        var g = "none";
        a && (g = "block"),
        this.getElement().css("display", g)
    },
    lg.Widgets.BaseControl.prototype.getIsValid = function(a, g) {
        return this.execValid(a, g),
        this._data.valid.validResult
    },
    lg.Widgets.BaseControl.prototype.setValid = function(a) {
        for (var g in a) this._data.valid._map[g].is = a[g]
    },
    lg.Widgets.BaseControl.prototype.getValue = function() {
        return this._value = "undefined" == typeof this.getElement().find("input[type="text"]").val() ? this.getElement().find("input[type="password"]").val() : this.getElement().find("input[type="text"]").val(),
        this._value = "undefined" == typeof this._value ? "": this._value,
        this._value = this._value.trim(),
        this._value
    },
    lg.Widgets.BaseControl.prototype.setValue = function(a) {
        this._value = this.getElement().find("input[type="text"]").val(a) || this.getElement().find("input[type="password"]").val(a)
    },
    lg.Widgets.BaseControl.prototype.execValid = function(val, type) {
        var thisType = type || "blur";
        if ("undefined" != typeof val && this.getIsVisible()) for (var item in this._data.valid._map) if ("object" == typeof this._data.valid._map[item] && this._data.valid._map[item].isUse) {
            if ("require" == this._data.valid._map[item].mode && this.controlValidResult(0 == val.length && this._isDirty && this._data.valid._map[item].trigger.indexOf(thisType) > -1, item, type), "min-len" == this._data.valid._map[item].mode && this.controlValidResult(val.length < this._data.valid._map[item].data && this._isDirty && this._data.valid._map[item].trigger.indexOf(thisType) > -1, item, type), "max-len" == this._data.valid._map[item].mode && this.controlValidResult(val.length > this._data.valid._map[item].data && this._isDirty && this._data.valid._map[item].trigger.indexOf(thisType) > -1, item, type), "repeat-password" == this._data.valid._map[item].mode) {
                var pwd = lg.Cache.Views[this._option.parentName].field[this._option.linkFor].getValue(),
                repwd = this.getValue();
                this.controlValidResult(pwd != repwd && this._isDirty && this._data.valid._map[item].trigger.indexOf(thisType) > -1, item, type)
            }
            if ("pattern" == this._data.valid._map[item].mode) {
                if ("string" == typeof this._data.valid._map[item].data) for (var data = this._data.valid._map[item].data.split("||"), temp = !1, i = 0, len = data.length; len > i; i++) {
                    var reg = eval(data[i]);
                    temp = temp || reg.test(val)
                } else {
                    var data = this._data.valid._map[item].data,
                    temp = !1;
                    for (var i in data)"function" != typeof data[i] && (temp = temp || data[i].test(val))
                }
                this.controlValidResult(!temp && this._isDirty && this._data.valid._map[item].trigger.indexOf(thisType) > -1, item, type)
            }
        }
    },
    lg.Widgets.BaseControl.prototype.getSelfIsValided = function() {
        var value = !0,
        val = this.getValue();
        if ("undefined" == typeof val) return ! 1;
        for (var item in this._data.valid._map) if ("object" == typeof this._data.valid._map[item] && this._data.valid._map[item].isUse) {
            if ("require" == this._data.valid._map[item].mode && (value = value && 0 != val.length ? !0 : !1), "min-len" == this._data.valid._map[item].mode && (value = value && val.length > this._data.valid._map[item].data ? !0 : !1), "max-len" == this._data.valid._map[item].mode && (value = value && val.length < this._data.valid._map[item].data ? !0 : !1), "repeat-password" == this._data.valid._map[item].mode) {
                var pwd = lg.Cache.Views[this._option.parentName].field[this._option.linkFor].getValue(),
                repwd = this.getValue();
                value = value && pwd == repwd ? !0 : !1
            }
            if ("pattern" == this._data.valid._map[item].mode) {
                if ("string" == typeof this._data.valid._map[item].data) for (var data = this._data.valid._map[item].data.split("||"), temp = !1, i = 0, len = data.length; len > i; i++) {
                    var reg = eval(data[i]);
                    temp = temp || reg.test(val)
                } else {
                    var data = this._data.valid._map[item].data,
                    temp = !1;
                    for (var i in data)"function" != typeof data[i] && (temp = temp || data[i].test(val))
                }
                value = value && temp ? !0 : !1
            }
        }
        return value
    },
    lg.Widgets.BaseControl.prototype.controlValidResult = function(a, g, h) {
        a ? (this._data.valid.validResult[this._data.valid._map[g].mode] = this._data.valid._map[g], this._data.valid.validResult[this._data.valid._map[g].mode].triggerType = h) : delete this._data.valid.validResult[this._data.valid._map[g].mode]
    },
    lg.Widgets.Controls = {},
    lg.Widgets.Controls.Phone = function(a, g) {
        lg.Widgets.Controls[a] = g(a)
    },
    lg.Widgets.Controls.Extend = function(a, g) {
        lg.Widgets.Controls[a] = g(a)
    },
    lg.Widgets.Controls.Extend("Phone",
    function(a) {
        var g = function(a, g) {
            lg.Widgets.BaseControl.call(this, a, g)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g
    }),
    lg.Widgets.Controls.Extend("PhoneVerificationCode",
    function(a) {
        var g = function(a, g) {
            lg.Widgets.BaseControl.call(this, a, g)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g.prototype.getTopTime = function() {
            return this._option.topTime || 60
        },
        g.prototype.setTopTime = function(a) {
            this._option.topTime = a
        },
        g.prototype.getopCount = function() {
            return this._option.topCount || null
        },
        g.prototype.getTotalCount = function() {
            return this._option.totalCount
        },
        g.prototype.setTotalTimeTemp = function() {
            this.totalTimeTemp = this.getTopTime()
        },
        g.prototype.setTimeLine = function(a) {
            this._option.timeLine = a
        },
        g.prototype.getPhoneVerificationCodeUrl = function() {
            return this._option.url
        },
        g.prototype.getVerificationButton = function() {
            return this.getElement().find("input[type="button"]")
        },
        g.prototype.getVerificationInput = function() {
            return this.getElement().find("input[type="text"]")
        },
        g.prototype.getCodeIsDisabled = function() {
            return this.getElement().find("input[type="button"]").hasClass("btn_disabled")
        },
        g.prototype.setCodeIsDisabled = function(a) {
            var g = !1;
            return a ? (g = !0, this.getElement().find("input[type="button"]").addClass("btn_disabled"), g) : (this.getElement().find("input[type="button"]").removeClass("btn_disabled"), g)
        },
        g.prototype.getLinkFor = function() {
            return lg.Cache.Views[this._option.parentName].field[this._option.linkFor]
        },
        g.prototype.init = function() {
            clearInterval(this.timeLine),
            this.timeLine = null,
            this.isActive = !1,
            this.setCodeIsDisabled(this._option.codeIsDisabled);
            var a = lg.Cache.Views[this._option.parentName].field[this._option.linkFor]; ! a.getSelfIsValided() && a._option.keyup ? this.getVerificationButton().val("string" != typeof this._option.postfix ? "获取验证码": "获取") : a.getSelfIsValided() && a._option.keyup && this.getVerificationButton().removeClass("btn_disabled").val("string" != typeof this._option.postfix ? "获取验证码": "获取"),
            this.totalTimeTemp = this.getTopTime(),
            this.getElement().find("input[type="button"]").one("click", {
                control: this
            },
            function(e) {
                var a = e.data.control,
                g = !0,
                h = lg.Cache.Views[a._option.parentName].field[a._option.linkFor],
                c = lg.Cache.Views[a._option.parentName].field[a._option.verifyCode];
                c.getIsVisible() && (g = c.getSelfIsValided() && g ? !0 : !1),
                g = h.getSelfIsValided() && g ? !0 : !1,
                g ? (a.setDisable(!0), !a.getCodeIsDisabled() && a.getIsDisabled() && (a.isActive = !0, a._option.click.call(this, {
                    control: a,
                    parent: lg.Cache.Views[a._option.parentName],
                    linkFor: h
                }))) : (h._isDirty = !0, h.setValidMessage(h.getIsValid(h.getValue()), "CollectData"), c.getIsVisible() && (c._isDirty = !0, c.setValidMessage(c.getIsValid(c.getValue()), "CollectData")), a.init())
            })
        },
        g.prototype.getVerificationCode = function() {},
        g.prototype.setClear = function() {
            this.getElement().find("input.input_warning").removeClass("input_warning"),
            this.getElement().find("[data-valid-message]").remove(),
            this.getElement().find("input[type="text"],input[type="password"]").val(""),
            this._isDirty = !1,
            this.getElement().find("input[type="text"],input[type="password"]").blur();
            var a = $._data(this.getElement().find("input[type="button"]")[0], "events");
            a && a.click || this.init(),
            this.timeLine && clearInterval(this.timeLine),
            this.timeLine = null,
            this.setDisable(!1);
            var g = lg.Cache.Views[this._option.parentName].field[this._option.linkFor]; ! g.getSelfIsValided() && g._option.keyup ? this.getVerificationButton().val("string" != typeof this._option.postfix ? "获取验证码": "获取") : this.getVerificationButton().removeClass("btn_disabled").val("string" != typeof this._option.postfix ? "获取验证码": "获取")
        },
        g.prototype.starttime = function(a, g) {
            a.timeLine || (a.totalTimeTemp = a.getTopTime(), a.timeLine = setInterval(function() {
                var h = lg.Cache.Views[a._option.parentName].field[a.getName()];
                h.totalTimeTemp--;
                var c = "string" != typeof h._option.postfix ? "秒后重试": h._option.postfix + "s";
                if (h.getVerificationButton().addClass("btn_disabled").val(h.totalTimeTemp + c), -1 == h.totalTimeTemp) {
                    clearInterval(h.timeLine),
                    h.timeLine = null,
                    a.setDisable(!1);
                    var v = lg.Cache.Views[a._option.parentName].field[a._option.linkFor]; ! v.getSelfIsValided() && v._option.keyup ? (h.init(), h.getVerificationButton().val("string" != typeof h._option.postfix ? "获取验证码": "获取")) : (h.init(), h.getVerificationButton().removeClass("btn_disabled").val("string" != typeof h._option.postfix ? "获取验证码": "获取")),
                    "function" == typeof g && g()
                }
            },
            1e3))
        },
        g
    }),
    lg.Widgets.Controls.Extend("Password",
    function(a) {
        var g = function(a) {
            lg.Widgets.BaseControl.call(this, a)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g
    }),
    lg.Widgets.Controls.Extend("RepeatPassword",
    function(a) {
        var g = function(a) {
            lg.Widgets.BaseControl.call(this, a)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g
    }),
    lg.Widgets.Controls.Extend("Email",
    function(a) {
        var g = function(a) {
            lg.Widgets.BaseControl.call(this, a)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g
    }),
    lg.Widgets.Controls.Extend("VerifyCode",
    function(a) {
        var g = function(a) {
            lg.Widgets.BaseControl.call(this, a)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g.prototype.init = function() {
            this.getVerifyCodeReflashButton().on("click", {
                control: this
            },
            function(e) {
                var a = e.data.control._element,
                g = e.data.control.getVerifyCodeUrl(),
                h = $("<img alt="点击重试" class="yzm" width="98" height="40" />");
                if ("init" == e.data.type) {
                    if (e.data.control.getVerifyCodeImg().attr("src")) return;
                    h.attr("src", g),
                    a.find("img").remove(),
                    a.find("input").after(h)
                } else h.attr("src", g),
                a.find("img").remove(),
                a.find("input").after(h)
            })
        },
        g.prototype.getVerifyCode = function() {
            this.getVerifyCodeReflashButton().trigger("click", {
                control: this,
                type: "init"
            })
        },
        g.prototype.getFrom = function() {
            return this._option.from || "register"
        },
        g.prototype.getVerifyCodeUrl = function() {
            var a = this._option.url + "?from=" + this.getFrom() + "&refresh=" + (new Date).getTime();
            return a
        },
        g.prototype.getVerifyCodeReflashButton = function() {
            return this.getElement().find("a")
        },
        g.prototype.getVerifyCodeInput = function() {
            return this.getElement().find("input")
        },
        g.prototype.getVerifyCodeImg = function() {
            return this.getElement().find("img")
        },
        g
    }),
    lg.Widgets.Controls.Extend("Switch",
    function(a) {
        var g = function(a) {
            lg.Widgets.BaseControl.call(this, a)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g.prototype.getValue = function() {
            return this.getElement().find(".btn_active").attr("data-myvalue") || ""
        },
        g
    }),
    lg.Widgets.Controls.Extend("CheckBox",
    function(a) {
        var g = function(a) {
            lg.Widgets.BaseControl.call(this, a)
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g.prototype.getValue = function() {
            var a = [];
            return this.getElement().find("input[type="checkbox"]:checked").each(function() {
                a.push($(this).attr("data-myvalue"))
            }),
            a
        },
        g
    }),
    lg.Widgets.Controls.Extend("Button",
    function(a) {
        var g = function(a) {
            lg.Widgets.BaseControl.call(this, a),
            this._isValueField = !1
        };
        return g.prototype = new lg.Widgets.BaseControl,
        g.prototype.controlType = a,
        g.prototype.init = function() {
            this.isActive = !1,
            this.getElement().find("[type="button"]").on("click", {
                control: this
            },
            function(e) {
                var a = e.data.control;
                a.isActive = !0,
                a._option.click.call(this, {
                    control: a,
                    parent: lg.Cache.Views[a._option.parentName]
                })
            })
        },
        g
    }),
    lg.Views = lg.Views || {},
    lg.Views.BaseView = function(a) {
        this._name = "",
        this._children = [],
        this._Validation = {},
        this._options = {},
        this.childrenData = {},
        this.field = {},
        a && (this._name = a.name),
        $.extend(this._options, a),
        this._element = "string" == typeof a.name ? $("[data-view="" + this._name + ""]") : this._name,
        lg.Cache.Views[this._name] = this,
        this.init()
    },
    lg.Views.BaseView.prototype.getElement = function() {
        return this._element
    },
    lg.Views.BaseView.prototype.setClear = function() {
        for (var a in this.field) this.field[a].setClear()
    },
    lg.Views.BaseView.prototype.ValidatForm = function() {
        for (var a in this.field) {
            var i = {};
            this.field[a].getIsValueField() && (this.field[a]._isDirty = !0, i = this.field[a].getIsValid(this.field[a].getValue())),
            lg.Utils.isNullObject(i) ? this._Validation[a] = i: delete this._Validation[a]
        }
        if (lg.Utils.isNullObject(this._Validation)) {
            for (var a in this._Validation) this.field[a].setValidMessage(this._Validation[a], "CollectData");
            return ! 1
        }
        return ! 0
    },
    lg.Views.BaseView.prototype.CollectData = function(a) {
        this.childrenData.isValidate = !0,
        a || (this.childrenData.isValidate = this.ValidatForm());
        for (var g in this.field) this.field[g].getIsValueField() && (this.childrenData[g] = this.field[g] ? this.field[g].getValue() : "");
        return this.childrenData
    },
    lg.Views.BaseView.prototype.init = function() {
        this._options,
        this._options.fields ? this.initControls(this._options.fields) : ""
    },
    lg.Views.BaseView.prototype.initControls = function(a) {
        for (var i = 0,
        g = a.length; g > i; i++) a[i].parentName = this._name,
        this.field[a[i].name] = new lg.Widgets.Controls[a[i].controlType](a[i]),
        this.field[a[i].name].BaseInit()
    },
    lg.Views.BaseView.prototype.extend = function(a, g) {
        this[a] = g
    },
    lg.Models = lg.Models || {},
    lg.Models.BaseViewModel = function(a, g) {
        a && (this._name = a),
        this._name = "",
        $.extend(this._options, g)
    },
    module.exports = lg
});
/*!common/widgets/passport/modules/country-code/main.js*/
;
define("common/widgets/passport/modules/country-code/main", ["require", "exports", "module"],
function(require, exports, module) {
    function a(a, v) {
        for (var _ = a; _[c];) {
            if (_.hasClass(v)) return ! 0;
            _ = _.parent()
        }
        return ! 1
    }
    var c = 0,
    v = 0,
    _ = 1,
    h = $(".area_code_list"),
    g = $(".area_code");
    $(document).on("click", ".area_code",
    function() {
        return h.is(":visible") ? ($(this).removeClass("active"), h.hide()) : ($(this).addClass("active"), h.show().scrollTop(v)),
        !1
    }),
    $(document).on("click", ".area_code_list dd",
    function() {
        var a = $(this),
        c = a.parents(".area_code_list").prev();
        return c.text(a.children("span").text()),
        c.trigger("click"),
        !1
    }),
    $(document).on("click",
    function(c) {
        var v = $(c.target);
        return a(v, "area_code_list") ? !1 : (g.removeClass("active"), void h.hide())
    }),
    $.lgAjax({
        url: GLOBAL_DOMAIN.pctx + "/register/getPhoneCountryCode.json",
        dataType: "jsonp",
        jsonp: "jsoncallback",
        success: function(a) {
            var v = "",
            h = a.content.rows;
            if (g.text(h[c].countryList[c].code), a.state === _ && h) for (var y = c,
            C = h.length; C > y; y++) {
                v += "<dt>" + h[y].name + "</dt>";
                for (var i = c,
                L = h[y].countryList.length; L > i; i++) v += "<dd>" + h[y].countryList[i].name + "<span>" + h[y].countryList[i].code + "</span></dd>"
            } else v = "请求出错";
            $(".code_list_main").append(v)
        }
    }),
    module.exports = function() {
        var a = $(".area_code_list dd").eq(0).find("span").text();
        $(".area_code").text(a).removeClass("active"),
        h.hide()
    }
});
/*!common/widgets/passport/utils/index.js*/
;
define("common/widgets/passport/utils/index", ["require", "exports", "module"],
function(require, exports, module) {
    function a(a) {
        var c = top.location,
        y = {
            protocol: c.protocol.substring(0, c.protocol.length - 1),
            hostname: c.hostname,
            port: c.port || "80"
        },
        g = v.exec(a.url);
        if (g && g.length) {
            var h = {
                protocol: g[1],
                hostname: g[2],
                port: g[3] || "80"
            }; (y.protocol != h.protocol || y.hostname != h.hostname || y.port != h.port) && (a.dataType = "jsonp", a.jsonp = "jsoncallback")
        }
    }
    var c = "0.0.1",
    y = 0,
    g = !1,
    v = /^(https?):\/\/((?:[\u4E00-\u9FA5a-z0-9.-]|%[0-9A-F]{2}){2,})(?::(\d+))?((?:\/(?:[a-z0-9-._~!$&"()*+,;=:@]|%[0-9A-F]{2})*)*)(?:\?((?:[a-z0-9-._~!$&"()*+,;=:\/?@]|%[0-9A-F]{2})*))?(?:#((?:[a-z0-9-._~!$&"()*+,;=:\/?@]|%[0-9A-F]{2})*))?$/i,
    h = {
        getUniqueIndex: function() {
            return++y
        },
        createIframe: function(a, c, y) {
            var g = "<iframe src="" + c + "" id="" + a + "_" + y + "" style="display:none;"></iframe>";
            $("body").append(g)
        },
        delIframe: function(a, c) {
            var y = a + "_" + c;
            $("#" + y).remove(),
            j.tinfo("Iframe " + y + " removed")
        }
    },
    j = {
        iframe: h,
        rpc: function(c) {
            if (c.url) {
                c.type || (c.type = "POST"),
                c.params || (c.params = {});
                var y = arguments.callee;
                j.tinfo("Start passport.rpc: " + c.url);
                var g = {
                    type: c.type,
                    data: c.params,
                    url: c.url,
                    dataType: "json"
                };
                a(g),
                $.lgAjax(g).done(function(a, g) {
                    if (j.tinfo("passport.rpc.succ: " + g), "10001" == a.state) {
                        var v = a.content.data.crossServiceUrl.replace(/^https?\:/i, window.location.protocol);
                        return void PASSPORT.remote(v,
                        function() {
                            j.tinfo("passport.rpc.remote.succ"),
                            y(c)
                        },
                        function(a) {
                            j.tinfo("passport.rpc.remote.fail"),
                            c.fail && c.fail.apply(null, [a])
                        })
                    }
                    c.succ && c.succ.apply(null, arguments)
                }).fail(function(a, y) {
                    j.tinfo("passport.rpc.fail: " + y),
                    c.fail && c.fail.apply(null, arguments)
                })
            }
        },
        getTargetUrl: function(a, c) {
            var y = {
                fl: void 0 != c.fl ? c.fl: !0,
                service: c.service,
                osc: c.osc,
                ofc: c.ofc,
                pfurl: document.URL
            };
            return a + "?" + $.param(y)
        },
        getCurEncodeUrl: function() {
            return encodeURIComponent(document.URL)
        },
        requester: function(a, c) {
            a.dataType = a.dataType || "json",
            a.type = a.type || "POST",
            a.data = a.data || {},
            $.lgAjax(a).done(function(a) {
                c && c(a)
            })
        },
        strFormat: function(a, c) {
            a = String(a);
            var y = Array.prototype.slice.call(arguments, 1),
            g = Object.prototype.toString;
            return y.length ? (y = 1 == y.length && null !== c && /\[object Array\]|\[object Object\]/.test(g.call(c)) ? c: y, a.replace(/#\{(.+?)\}/g,
            function(a, c) {
                var v = y[c];
                return "[object Function]" == g.call(v) && (v = v(c)),
                "undefined" == typeof v ? "": v
            })) : a
        },
        tipheader: "Lagou Passport v" + c + " -> ",
        tip: function() {
            if (g) {
                var a = arguments[0],
                c = Array.prototype.slice.call(arguments, 1);
                console[a].apply(console, c)
            }
        },
        tinfo: function(a) {
            j.tip("info", j.tipheader + a)
        }
    };
    module.exports = j
});
/*!common/widgets/passport/modules/login/main.js*/
;
define("common/widgets/passport/modules/login/main", ["require", "exports", "module", "common/components/util/htoc", "common/widgets/passport/common/js/sense", "common/widgets/passport/modules/wechat-qrcode/main", "common/components/modal/modal", "common/widgets/passport/common/js/lagou", "common/widgets/passport/modules/country-code/main", "common/widgets/passport/utils/index"],
function(require, exports, module) {
    function a(a) {
        if (!P) {
            P = !0;
            var c = {
                parent: R
            },
            g = c.parent.CollectData(),
            F = "veenike";
            g.isValidate && (g.password = md5(g.password), g.password = md5(F + g.password + F), a && (g = b.getParam(g, a)), $.lgAjax({
                data: g,
                url: GLOBAL_DOMAIN.pctx + "/login/login.json",
                dataType: "jsonp",
                jsonp: "jsoncallback"
            }).done(function(a) {
                if (j[210].message = "请输入有效的手机/邮箱", j[400].message = "账号和密码不匹配", j[400].linkFor = "password", 1 == a.state) {
                    var g = V.iframe.getUniqueIndex(),
                    F = V.getTargetUrl(GLOBAL_DOMAIN.pctx + "/ajaxLogin/frameGrant.html", {
                        fl: "2",
                        service: window.CURRENT_SLIDER_BAR_URL || document.URL,
                        osc: "PASSPORT._pscb(" + g + ")",
                        ofc: "PASSPORT._pfcb(" + g + ")"
                    });
                    V.iframe.createIframe("popup_login_iframe", F, g)
                } else 10010 == a.state && (c.parent.field.request_form_verifyCode.getVerifyCode(), c.parent.field.request_form_verifyCode.setVisible(!0)),
                j[a.state] ? c.parent.field[j[a.state].linkFor].showMessage({
                    message: j[a.state].message
                }) : c.parent.field.password.showMessage({
                    message: a.message
                }),
                P = !1
            }).fail(function() {
                P = !1
            }))
        }
    }
    function c(e, a) {
        var c = e;
        if ( - 1 == c.control.totalTimeTemp || c.control.totalTimeTemp == c.control.getTopTime()) {
            var g = {
                countryCode: $("[data-view="codeLogin"] .area_code").text(),
                phone: c.linkFor.getValue(),
                type: 0,
                request_form_verifyCode: k.Cache.Views[c.control._option.parentName].field.request_form_verifyCode.getValue()
            };
            a && (g = b.getParam(g, a)),
            $.lgAjax({
                url: c.control._option.url,
                data: g,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                cache: !1
            }).done(function(a) {
                var g;
                return e.control.setDisable(!1),
                L[a.state] && c.parent.field[L[a.state].linkFor].showMessage({
                    message: L[a.state].message
                }),
                1 == a.state ? (g = $(".login-pop .passport-pop-wrapper.account [data-propertyname="phoneVerificationCode"]"), $(".verify_tips_main").hide(), void e.control.starttime(e.control,
                function() {
                    $(".login-pop .passport-pop-wrapper.account .auto_phone").val("语音验证"),
                    $(".login-pop .passport-pop-wrapper.account .verify_tips_main").show(),
                    g.find(".first_child").removeClass("input_warning"),
                    g.children(".input_tips").remove()
                })) : (e.control.init(), void c.parent.field.request_form_verifyCode.getVerifyCode())
            }).fail(function() {
                e.control.setDisable(!1),
                e.control.init(),
                c.parent.field.request_form_verifyCode.getVerifyCode()
            })
        }
    }
    function g(e, a) {
        var c = e;
        if ( - 1 == c.control.totalTimeTemp || c.control.totalTimeTemp == c.control.getTopTime()) {
            var g = {
                countryCode: $("[data-view="codeLogin"] .area_code").text(),
                phone: c.linkFor.getValue(),
                type: 1,
                request_form_verifyCode: k.Cache.Views[c.control._option.parentName].field.request_form_verifyCode.getValue()
            };
            a && (g = b.getParam(g, a)),
            $.lgAjax({
                url: c.control._option.url,
                data: g,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                cache: !1
            }).done(function(a) {
                var g, F = L[a.state],
                _ = c.control.getTopTime();
                1 === a.state ? (g = $(".login-pop .passport-pop-wrapper.account [data-propertyname="phoneVerificationCode"]"), g.find(".last_child").addClass("btn_disabled").prop("disabled", !0), clearInterval(A), A = setInterval(function() {--_ < 0 ? (clearInterval(A), g.find(".first_child").removeClass("input_warning"), g.find(".last_child").removeClass("btn_disabled").removeProp("disabled"), $(".login-pop .auto_phone").removeProp("disabled"), $(".login-pop .verify_tips_count_down").hide(), $(".login-pop .verify_tips_main").show(), e.control.init()) : (_ === c.control.getTopTime() - 1 && $(".login-pop .verify_tips_main").hide(), $(".login-pop .verify_tips_count_down").html("请留意接收手机来电，" + _ + "秒后可重试…").show())
                },
                1e3)) : (e.control.init(), F && c.parent.field[F.linkFor].showMessage({
                    message: F.message
                }), c.parent.field.request_form_verifyCode.getVerifyCode()),
                e.control.setDisable(!1)
            })
        }
    }
    function F(a) {
        if (!I) {
            I = !0;
            var c = {
                parent: E
            },
            g = c.parent.CollectData();
            g.countryCode = $(".login-pop [data-view="codeLogin"] .area_code").text(),
            a && (g.challenge = a),
            g.isValidate ? $.lgAjax({
                url: GLOBAL_DOMAIN.pctx + "/login/login.json",
                data: g,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                cache: !1
            }).done(function(a) {
                if (I = !1, j[210].message = "输入号码与归属地不匹配", j[400].message = "账号和验证码不匹配", j[400].linkFor = "phoneVerificationCode", 1 == a.state) {
                    var g = V.iframe.getUniqueIndex(),
                    F = V.getTargetUrl(GLOBAL_DOMAIN.pctx + "/ajaxLogin/frameGrant.html", {
                        fl: "2",
                        service: window.CURRENT_SLIDER_BAR_URL || document.URL,
                        osc: "PASSPORT._pscb(" + g + ")",
                        ofc: "PASSPORT._pfcb(" + g + ")"
                    });
                    V.iframe.createIframe("popup_login_iframe", F, g)
                } else 10010 == a.state && (c.parent.field.request_form_verifyCode.getVerifyCode(), c.parent.field.request_form_verifyCode.setVisible(!0)),
                j[a.state] ? c.parent.field[j[a.state].linkFor].showMessage({
                    message: j[a.state].message
                }) : c.parent.field.phoneVerificationCode.showMessage({
                    message: a.message
                }),
                c.parent.field.request_form_verifyCode.getVerifyCode(),
                I = !1
            }).fail(function() {
                I = !1
            }) : I = !1
        }
    }
    function _(a) {
        return "code" === a ? ($(".login-pop .forms-area").removeClass("password"), void $(".login-pop .passport-pop-wrapper.wechat .change-btn").removeClass("password")) : "password" === a ? ($(".login-pop .forms-area").addClass("password"), void $(".login-pop .passport-pop-wrapper.wechat .change-btn").addClass("password")) : void 0
    }
    var v = require("common/components/util/htoc"),
    C = require("common/widgets/passport/common/js/sense"),
    w = require("common/widgets/passport/modules/wechat-qrcode/main");
    require("common/components/modal/modal");
    var h, y, b, k = require("common/widgets/passport/common/js/lagou"),
    D = require("common/widgets/passport/modules/country-code/main"),
    V = require("common/widgets/passport/utils/index"),
    T = new w({
        wrapper: ".login-pop",
        isLogin: !0
    }),
    A = null,
    j = {
        1 : {
            message: "成功",
            linkFor: "username",
            level: "info"
        },
        210 : {
            message: "请输入有效的手机/邮箱",
            linkFor: "username",
            level: "error"
        },
        211 : {
            message: "请输入6-16位密码，字母区分大小写",
            linkFor: "password",
            level: "error"
        },
        220 : {
            message: "请输入已验证手机/邮箱",
            linkFor: "username",
            level: "error"
        },
        241 : {
            message: "请输入密码",
            linkFor: "password",
            level: "error"
        },
        400 : {
            message: "账号和密码不匹配",
            linkFor: "password",
            level: "error"
        },
        10010 : {
            message: "图形验证码不正确",
            linkFor: "request_form_verifyCode",
            level: "error"
        },
        10011 : {
            message: "登录错误次数过多，请稍后再试或<a href="https://passport.lagou.com/accountPwd/toReset.html">重置密码</a>",
            linkFor: "password",
            level: "error"
        },
        10012 : {
            message: "操作过于频繁，请联系管理员",
            linkFor: "password",
            level: "error"
        }
    },
    L = {
        1 : {
            message: "验证码已发送，请查收短信",
            linkFor: "phoneVerificationCode",
            level: "info"
        },
        201 : {
            message: "请输入手机号码",
            linkFor: "username",
            level: "error"
        },
        203 : {
            message: "输入号码与归属地不匹配",
            linkFor: "username",
            level: "error"
        },
        204 : {
            message: "系统错误",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        205 : {
            message: "输入号码与归属地不匹配",
            linkFor: "username",
            level: "error"
        },
        206 : {
            message: "系统错误",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        207 : {
            message: "该手机获取验证码已达上限，请明天再试",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        208 : {
            message: "验证码发送太过频繁，请稍后再试",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        209 : {
            message: "该手机已被注册，请重新输入或直接登录",
            linkFor: "username",
            level: "error"
        },
        222 : {
            message: "该手机号未注册",
            linkFor: "username",
            level: "error"
        },
        304 : {
            message: "用户未登录",
            linkFor: "username",
            level: "error"
        },
        402 : {
            message: "获取验证码超时，请稍后再试",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        10010 : {
            message: "图形验证码不正确",
            linkFor: "request_form_verifyCode",
            level: "error"
        },
        10011 : {
            message: "操作过于频繁，请联系管理员",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        10012 : {
            message: "操作过于频繁，请联系管理员",
            linkFor: "phoneVerificationCode",
            level: "error"
        }
    },
    R = new k.Views.BaseView({
        name: "passwordLogin",
        fields: [{
            name: "username",
            validRules: [{
                mode: "require",
                data: "",
                message: "请输入已验证手机/邮箱",
                trigger: "blur"
            },
            {
                mode: "pattern",
                isUse: !0,
                status: !1,
                data: {
                    phone: /^\d{5,15}$/,
                    email: /^((([a-z]|\d|[!#\$%&"\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&"\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i
                },
                message: "请输入有效的手机/邮箱"
            }],
            controlType: "Phone"
        },
        {
            name: "password",
            validRules: [{
                mode: "require",
                data: "",
                message: "请输入密码"
            },
            {
                mode: "pattern",
                data: "/^[\\S\\s]{6,16}$/",
                message: "请输入6-16位密码，字母区分大小写"
            }],
            controlType: "Password"
        },
        {
            name: "request_form_verifyCode",
            isVisible: !1,
            validRules: [],
            from: "register",
            url: "https://passport.lagou.com/vcode/create",
            controlType: "VerifyCode"
        }]
    });
    $(".HtoC_JS").each(function() {
        $(this).keyup(function() {
            v.HtoC($(this))
        })
    }),
    $(".input_border input").focus(function() {
        $(this).parents(".input_border").attr("class", "input_border focus")
    }),
    $(".input_border input").blur(function() {
        $(this).parents(".input_border").attr("class", "input_border")
    }),
    $(".login_enter_password").keydown(function(c) {
        if (13 === c.keyCode) {
            if (window.LGWebTj && window.LGWebTj({
                _lt: "pcclick",
                _address_id: "1m2g",
                added_props: {
                    action_type: "enter",
                    tjEncodeId: "1m2g",
                    tjNo: "0003"
                }
            }), !h) return void console.log("初始化中 请稍后");
            if (y) {
                if (!b) return;
                if (!R.ValidatForm()) return;
                b.sense({
                    level: 2,
                    successCallback: a,
                    closeCallback: function() {
                        console.log("close sense")
                    }
                })
            } else a()
        }
    }),
    $(".login-btn.login-password").bind("click",
    function() {
        if (!h) return void console.log("初始化中 请稍后");
        if (y) {
            if (!b) return;
            if (!R.ValidatForm()) return;
            b.sense({
                level: 2,
                successCallback: a,
                closeCallback: function() {
                    console.log("close sense")
                }
            })
        } else a()
    });
    var P = !1;
    R.field.request_form_verifyCode.getVerifyCode();
    var E = new k.Views.BaseView({
        name: "codeLogin",
        fields: [{
            name: "username",
            validRules: [{
                mode: "require",
                data: "",
                message: "请输入已验证手机",
                trigger: "blur"
            },
            {
                mode: "pattern",
                isUse: !0,
                status: !1,
                data: {
                    phone: /^\d{5,11}$/
                },
                message: "请输入有效的手机"
            }],
            controlType: "Phone"
        },
        {
            name: "request_form_verifyCode",
            isVisible: !y,
            validRules: [{
                mode: "require",
                data: "",
                message: "请输入验证码"
            },
            {
                mode: "pattern",
                data: "/^[a-zA-Z0-9一-龥]{4,4}$/",
                message: "请输入正确的验证码"
            }],
            from: "register",
            url: "https://passport.lagou.com/vcode/create",
            controlType: "VerifyCode"
        },
        {
            name: "phoneVerificationCode",
            linkFor: "username",
            verifyCode: "request_form_verifyCode",
            totalTips: "该手机获取验证码已达上限，请明天再试",
            validRules: [{
                mode: "require",
                data: "",
                message: "请输入6位数字验证码"
            },
            {
                mode: "pattern",
                isUse: !0,
                status: !1,
                data: "/^[0-9]{6,6}$/",
                message: "请输入6位数字验证码"
            }],
            url: GLOBAL_DOMAIN.pctx + "/login/sendLoginVerifyCode.json",
            controlType: "PhoneVerificationCode",
            click: function(e) {
                if (!h) return void console.log("初始化中 请稍后");
                if (y) {
                    if (!b) return;
                    b.sense({
                        level: 3,
                        successCallback: function(a) {
                            c(e, a)
                        },
                        closeCallback: function() {
                            e.control.setDisable(!1),
                            e.control.init()
                        }
                    })
                } else c(e)
            }
        },
        {
            name: "autoPhoneVerificationCode",
            linkFor: "username",
            verifyCode: "request_form_verifyCode",
            validRules: [],
            url: GLOBAL_DOMAIN.pctx + "/login/sendLoginVerifyCode.json",
            controlType: "PhoneVerificationCode",
            click: function(e) {
                if (!h) return void console.log("初始化中 请稍后");
                if (y) {
                    if (!b) return;
                    b.sense({
                        level: 3,
                        successCallback: function(a) {
                            g(e, a)
                        },
                        closeCallback: function() {
                            e.control.setDisable(!1),
                            e.control.init()
                        }
                    })
                } else g(e)
            }
        },
        {
            name: "submit",
            validRules: [],
            controlType: "Button",
            click: function() {}
        }]
    });
    $(".login_enter_code").keydown(function(a) {
        if (13 === a.keyCode) {
            if (window.LGWebTj && window.LGWebTj({
                _lt: "pcclick",
                _address_id: "1m2g",
                added_props: {
                    action_type: "enter",
                    tjEncodeId: "1m2g",
                    tjNo: "0003"
                }
            }), !h) return void console.log("初始化中 请稍后");
            if (y) {
                if (!b) return;
                F(111)
            } else F()
        }
    }),
    $(".login-btn.login-code").bind("click",
    function() {
        if (!h) return void console.log("初始化中 请稍后");
        if (y) {
            if (!b) return;
            F(111)
        } else F()
    });
    var I = !1;
    $(".forms-bottom-code .change-login-type").bind("click",
    function() {
        _("password")
    }),
    $(".forms-bottom-password .change-login-type").bind("click",
    function() {
        _("code")
    }),
    $(".login-pop  .account .change-btn").bind("click",
    function() {
        $(".login-pop .passport-pop-wrapper.wechat").fadeIn(),
        T.openQrCode()
    }),
    $(".login-pop .wechat .change-btn").bind("click",
    function() {
        $(".login-pop .passport-pop-wrapper.wechat").fadeOut(),
        T.closeQrCode()
    }),
    $(".register-btn").bind("click",
    function() {
        $(".login-pop").modal("hide"),
        PASSPORT.registerPopup()
    }),
    $(".login-pop .close").bind("click",
    function() {
        window.CURRENT_SLIDER_BAR_URL = null,
        T.closeQrCode()
    }),
    C(function(a) {
        b = a,
        h = "nolagou",
        y = !0,
        E && E.field.request_form_verifyCode.setVisible(!1)
    },
    function() {
        h = "lagou",
        y = !1,
        E && E.field.request_form_verifyCode.setVisible(!0),
        E && E.field.request_form_verifyCode.getVerifyCode()
    }),
    module.exports = function() {
        $(".login-pop .passport-pop-wrapper.wechat").hide(),
        _("password"),
        clearInterval(A),
        R.setClear(),
        E.setClear(),
        D(),
        $(".verify_tips_main").hide(),
        $(".verify_tips_count_down").hide(),
        $(".login-pop").modal("show")
    }
});
/*!common/widgets/passport/modules/register/main.js*/
;
define("common/widgets/passport/modules/register/main", ["require", "exports", "module", "common/components/util/htoc", "common/widgets/passport/common/js/sense", "common/widgets/passport/modules/wechat-qrcode/main", "common/components/modal/modal", "common/widgets/passport/common/js/lagou", "common/widgets/passport/modules/country-code/main"],
function(require, exports, module) {
    function a() {
        var a = $(".register-pop .forms-top-wrapper");
        return a.hasClass("account-b") ? "B": "C"
    }
    function c(e) {
        var c, g = e,
        h = g.parent.CollectData();
        if ("B" === a() ? (c = $("[data-view="phoneRegisterB"]"), h.type = 1) : (c = $("[data-view="phoneRegisterC"]"), h.type = 0), h.isValidate) {
            if (A) return;
            A = !0,
            y && (h.challenge = L, h.randstr = P),
            h.countryCode = c.find(".area_code").text(),
            $.lgAjax({
                url: GLOBAL_DOMAIN.pctx + "/register/register.json",
                data: h,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                cache: !1
            }).done(function(a) {
                var c = {
                    1 : {
                        message: "成功",
                        linkFor: "phoneVerificationCode",
                        level: "info"
                    },
                    203 : {
                        message: "输入号码与归属地不匹配",
                        linkFor: "phone",
                        level: "error"
                    },
                    209 : {
                        message: "该手机已被注册，请重新输入或直接登录",
                        linkFor: "phone",
                        level: "error"
                    },
                    222 : {
                        message: "输入号码与归属地不匹配",
                        linkFor: "phone",
                        level: "error"
                    },
                    240 : {
                        message: "请输入手机号码",
                        linkFor: "phone",
                        level: "error"
                    },
                    245 : {
                        message: "请输入6位数字验证码",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    401 : {
                        message: "手机验证码不正确",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    402 : {
                        message: "手机验证码不正确",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    403 : {
                        message: "系统错误",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    500 : {
                        message: "系统错误",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    501 : {
                        message: "系统错误",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    502 : {
                        message: "系统错误",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    10010 : {
                        message: "图形验证码不正确",
                        linkFor: "request_form_verifyCode",
                        level: "error"
                    },
                    10011 : {
                        message: "操作过于频繁，请联系管理员",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    },
                    10012 : {
                        message: "操作过于频繁，请联系管理员",
                        linkFor: "phoneVerificationCode",
                        level: "error"
                    }
                };
                if (a.state === O) {
                    if ("only_register" === I) window.location.href = GLOBAL_DOMAIN.pctx + "/grantServiceTicket/grant.html?service=" + encodeURIComponent(window.location.href);
                    else {
                        var h = GLOBAL_DOMAIN.pctx + "/grantServiceTicket/grant.html";
                        window.location.href = h
                    }
                    A = !0
                } else a.state === j && g.parent.field.request_form_verifyCode.setVisible(!0),
                c[a.state] ? g.parent.field[c[a.state].linkFor].showMessage({
                    message: c[a.state].message
                }) : g.parent.field.phoneVerificationCode.showMessage({
                    message: a.message
                }),
                g.parent.field.request_form_verifyCode.getVerifyCode(),
                A = !1
            }).fail(function() {
                A = !1
            })
        }
    }
    function g(e, c) {
        var g, h, C;
        "B" === a() ? (g = S.field.phoneVerificationCode, h = S, C = $("[data-view="phoneRegisterB"]")) : (g = G.field.phoneVerificationCode, h = G, C = $("[data-view="phoneRegisterC"]"));
        var _ = -1;
        if (g.totalTimeTemp === _ || g.totalTimeTemp === g.getTopTime()) {
            var w = {
                countryCode: C.find(".area_code").text(),
                phone: h.field.phone.getValue(),
                type: 0,
                request_form_verifyCode: F.Cache.Views[g._option.parentName].field.request_form_verifyCode.getValue()
            };
            c && (w = V.getParam(w, c)),
            $.lgAjax({
                url: GLOBAL_DOMAIN.pctx + "/register/isBlack/getPhoneVerificationCode.json",
                data: w,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                cache: !1
            }).done(function(a) {
                g.setDisable(!1);
                var _;
                return a.state === B ? void v(a.message) : (D[a.state] ? h.field[D[a.state].linkFor].showMessage({
                    message: D[a.state].message
                }) : h.field.phoneVerificationCode.showMessage({
                    message: a.message
                }), void(a.state === O || 203019 === a.state ? (c && (L = c.challenge, "tc_sense" === V.captchaType && (P = c.randstr)), _ = C.find("[data-propertyname="phoneVerificationCode"]"), C.find(".verify_tips_main").hide(), 203020 !== a.state && g.starttime(g,
                function() {
                    203019 !== a.state && 203020 !== a.state && (C.find(".verify_tips_main").show(), _.find(".first_child").removeClass("input_warning"), _.children(".input_tips").remove(), C.find(".auto_phone").val("语音验证"))
                })) : (g.init(), h.field.request_form_verifyCode.getVerifyCode())))
            })
        }
    }
    function h(e, c) {
        var g, h = e,
        C = -1;
        if (g = $("B" === a() ? "[data-view="phoneRegisterB"]": "[data-view="phoneRegisterC"]"), h.control.totalTimeTemp === C || h.control.totalTimeTemp === h.control.getTopTime()) {
            var _ = {
                countryCode: g.find(".area_code").text(),
                phone: h.linkFor.getValue(),
                type: 1,
                request_form_verifyCode: F.Cache.Views[h.control._option.parentName].field.request_form_verifyCode.getValue()
            };
            c && (_ = V.getParam(_, c)),
            $.ajax({
                url: GLOBAL_DOMAIN.pctx + "/register/getPhoneVerificationCode.json",
                data: _,
                dataType: "jsonp",
                jsonp: "jsoncallback",
                cache: !1
            }).done(function(a) {
                var C, _ = D[a.state],
                w = h.control.getTopTime(),
                y = 1e3,
                b = 1;
                return a.state === B ? void v(a.message) : (a.state === O ? (c && (L = c.challenge, V && "tc_sense" === V.captchaType && (P = c.randstr)), C = g.find("[data-propertyname="phoneVerificationCode"]"), C.find(".last_child").addClass("btn_disabled").prop("disabled", !0), clearInterval(k), k = setInterval(function() {--w < M ? (clearInterval(k), C.find(".first_child").removeClass("input_warning"), C.find(".last_child").removeClass("btn_disabled").removeProp("disabled"), g.find(".auto_phone").removeProp("disabled"), g.find(".verify_tips_count_down").hide(), g.find(".verify_tips_main").show(), h.control.init()) : (w === h.control.getTopTime() - b && g.find(".verify_tips_main").hide(), g.find(".verify_tips_count_down").html("请留意接收手机来电，" + w + "秒后可重试…").show())
                },
                y)) : (_ ? h.parent.field[_.linkFor].showMessage({
                    message: _.message
                }) : h.parent.field.phoneVerificationCode.showMessage({
                    message: a.message
                }), h.control.init(), h.parent.field.request_form_verifyCode.getVerifyCode()), void h.control.setDisable(!1))
            })
        }
    }
    function v(a) {
        console.log(a)
    }
    var C = require("common/components/util/htoc"),
    _ = require("common/widgets/passport/common/js/sense"),
    w = require("common/widgets/passport/modules/wechat-qrcode/main");
    require("common/components/modal/modal");
    var k, y, V, b, F = require("common/widgets/passport/common/js/lagou"),
    T = require("common/widgets/passport/modules/country-code/main"),
    j = 10010,
    B = 21010,
    A = !1,
    L = 111,
    P = 111,
    R = new w({
        wrapper: ".register-pop",
        isLogin: !1
    }),
    I = "registerAndLogin",
    O = 1,
    M = 0,
    D = {
        1 : {
            message: "验证码已发送，请查收短信",
            linkFor: "phoneVerificationCode",
            level: "info"
        },
        201 : {
            message: "请输入手机号码",
            linkFor: "phone",
            level: "error"
        },
        203 : {
            message: "输入号码与归属地不匹配",
            linkFor: "phone",
            level: "error"
        },
        204 : {
            message: "系统错误",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        205 : {
            message: "输入号码与归属地不匹配",
            linkFor: "phone",
            level: "error"
        },
        206 : {
            message: "系统错误",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        208 : {
            message: "验证码发送太过频繁，请稍后再试",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        209 : {
            message: "该手机已被注册，请重新输入或直接登录",
            linkFor: "phone",
            level: "error"
        },
        220 : {
            message: "输入号码与归属地不匹配",
            linkFor: "phone",
            level: "error"
        },
        222 : {
            message: "该手机号未注册",
            linkFor: "phone",
            level: "error"
        },
        304 : {
            message: "用户未登录",
            linkFor: "phone",
            level: "error"
        },
        310 : {
            message: "该手机获取验证码已达上限，请明天再试",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        311 : {
            message: "验证码发送太过频繁，请稍后再试",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        402 : {
            message: "手机验证码不正确",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        10010 : {
            message: "图形验证码不正确",
            linkFor: "request_form_verifyCode",
            level: "error"
        },
        10011 : {
            message: "操作过于频繁，请联系管理员",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        10012 : {
            message: "操作过于频繁，请联系管理员",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        203019 : {
            message: "已拨打语音电话，请留意接听，60s后可重试",
            linkFor: "phoneVerificationCode",
            level: "error"
        },
        203020 : {
            message: "检测到手机号存在风险，无法注册",
            linkFor: "phone",
            level: "error"
        }
    },
    N = [{
        name: "phone",
        validRules: [{
            mode: "require",
            data: "",
            message: "请输入手机号码",
            trigger: "blur"
        },
        {
            mode: "pattern",
            isUse: !0,
            status: !1,
            data: {
                phone: /^\d{5,11}$/
            },
            message: "请输入正确的手机号码"
        }],
        controlType: "Phone"
    },
    {
        name: "phoneVerificationCode",
        linkFor: "phone",
        verifyCode: "request_form_verifyCode",
        totalTips: "该手机获取验证码已达上限，请明天再试",
        validRules: [{
            mode: "require",
            data: "",
            message: "请输入6位数字验证码"
        },
        {
            mode: "pattern",
            isUse: !0,
            status: !1,
            data: "/^[0-9]{6,6}$/",
            message: "请输入6位数字验证码"
        }],
        url: "/register/getPhoneVerificationCode.json",
        controlType: "PhoneVerificationCode",
        click: function(e) {
            if (!b) return void console.log("初始化中 请稍后");
            if (y) {
                if (!V) return;
                V.sense({
                    level: 3,
                    successCallback: function(a) {
                        g(e, a)
                    },
                    closeCallback: function() {
                        e.control.setDisable(!1),
                        e.control.init()
                    }
                })
            } else g(e)
        }
    },
    {
        name: "autoPhoneVerificationCode",
        linkFor: "phone",
        verifyCode: "request_form_verifyCode",
        validRules: [],
        url: "/register/getPhoneVerificationCode.json",
        controlType: "PhoneVerificationCode",
        click: function(e) {
            if (!b) return void console.log("初始化中 请稍后");
            if (y) {
                if (!V) return;
                V.sense({
                    level: 3,
                    successCallback: function(a) {
                        h(e, a)
                    },
                    closeCallback: function() {
                        e.control.setDisable(!1),
                        e.control.init()
                    }
                })
            } else h()
        }
    },
    {
        name: "request_form_verifyCode",
        isVisible: !y,
        validRules: [{
            mode: "require",
            data: "",
            message: "请输入验证码"
        },
        {
            mode: "pattern",
            data: "/^[a-zA-Z0-9一-龥]{4,4}$/",
            message: "请输入正确的验证码"
        }],
        from: "register",
        url: "https://passport.lagou.com/vcode/create",
        controlType: "VerifyCode"
    },
    {
        name: "submit",
        validRules: [],
        controlType: "Button",
        url: "/register/register.json",
        click: c
    }],
    G = new F.Views.BaseView({
        name: "phoneRegisterC",
        fields: N
    }),
    S = new F.Views.BaseView({
        name: "phoneRegisterB",
        fields: N
    });
    $(".HtoC_JS").each(function() {
        $(this).keyup(function() {
            C.HtoC($(this))
        })
    }),
    $(".register_enter").keydown(function(g) {
        if (13 === g.keyCode) {
            if (window.LGWebTj && window.LGWebTj({
                _lt: "pcclick",
                _address_id: "1m2h",
                added_props: {
                    action_type: "enter",
                    tjEncodeId: "1m2h",
                    tjNo: "0002"
                }
            }), "B" === a()) return void c({
                parent: S
            });
            c({
                parent: G
            })
        }
    }),
    $("#register").bind("click",
    function() {
        return "B" === a() ? void c({
            parent: S
        }) : void c({
            parent: G
        })
    }),
    $(".register-pop .switch-tab div").bind("click",
    function() {
        var a = $(this);
        $(".register-pop .switch-tab div").removeClass("active"),
        a.addClass("active"),
        a.hasClass("tab-c") ? $(".register-pop .forms-top-wrapper").removeClass("account-b").addClass("account-c") : $(".register-pop .forms-top-wrapper").removeClass("account-c").addClass("account-b")
    }),
    $(".register-pop  .account .change-btn").bind("click",
    function() {
        $(".register-pop .passport-pop-wrapper.wechat").fadeIn(),
        R.openQrCode({
            registerType: a()
        })
    }),
    $(".register-pop .wechat .change-btn").bind("click",
    function() {
        $(".register-pop .passport-pop-wrapper.wechat").fadeOut(),
        R.closeQrCode()
    }),
    $(".register-pop .login-btn").bind("click",
    function() {
        $(".register-pop").modal("hide"),
        PASSPORT.loginPopup()
    }),
    $(".register-pop .close").bind("click",
    function() {
        R.closeQrCode()
    }),
    _(function(a) {
        V = a,
        y = !0,
        b = "nolagou",
        S && S.field.request_form_verifyCode.setVisible(!1),
        G && G.field.request_form_verifyCode.setVisible(!1)
    },
    function() {
        y = !1,
        b = "lagou",
        S && S.field.request_form_verifyCode.setVisible(!0),
        G && G.field.request_form_verifyCode.setVisible(!0),
        S && S.field.request_form_verifyCode.getVerifyCode(),
        G && G.field.request_form_verifyCode.getVerifyCode()
    }),
    module.exports = function(a) {
        I = a || "registerAndLogin",
        $(".register-pop .passport-pop-wrapper.wechat").hide(),
        $(".register-pop .switch-tab .tab-c").trigger("click"),
        S.setClear(),
        G.setClear(),
        clearInterval(k),
        T(),
        $(".verify_tips_main").hide(),
        $(".verify_tips_count_down").hide(),
        $(".register-pop").modal("show"),
        $(".area_code").text("0086")
    }
});
/*!common/components/util/emitter.js*/
;
define("common/components/util/emitter", ["require"],
function() {
    function a() {}
    var h = a.prototype;
    return h._getEvents = function() {
        return this._events || (this._events = {}),
        this._events
    },
    h._getMaxListeners = function() {
        return isNaN(this.maxListeners) && (this.maxListeners = 10),
        this.maxListeners
    },
    h.on = function(a, h) {
        var c = this._getEvents(),
        v = this._getMaxListeners();
        c[a] = c[a] || [];
        var g = c[a].length;
        if (g >= v && 0 !== v) throw new RangeError("Warning: possible Emitter memory leak detected. " + g + " listeners added.");
        return c[a].push(h),
        this
    },
    h.once = function(a, h) {
        function c() {
            v.off(a, c),
            h.apply(this, arguments)
        }
        var v = this;
        return c.listener = h,
        this.on(a, c),
        this
    },
    h.off = function(a, h) {
        var c = this._getEvents();
        if (0 === arguments.length) return this._events = {},
        this;
        var v = c[a];
        if (!v) return this;
        if (1 === arguments.length) return delete c[a],
        this;
        for (var g, i = 0; i < v.length; i++) if (g = v[i], g === h || g.listener === h) {
            v.splice(i, 1);
            break
        }
        return this
    },
    h.emit = function(a) {
        var h = this._getEvents(),
        c = h[a],
        v = Array.prototype.slice.call(arguments, 1);
        if (c) {
            c = c.slice(0);
            for (var i = 0,
            g = c.length; g > i; i++) c[i].apply(this, v)
        }
        return this
    },
    h.listeners = function(a) {
        var h = this._getEvents();
        return h[a] || []
    },
    h.setMaxListeners = function(a) {
        return this.maxListeners = a,
        this
    },
    a.mixin = function(h) {
        for (var c in a.prototype) h[c] = a.prototype[c];
        return h
    },
    a
});
/*!common/widgets/passport/dep/md5/md5.js*/
; !
function(c) {
    "use strict";
    function a(c, a) {
        var h = (65535 & c) + (65535 & a),
        d = (c >> 16) + (a >> 16) + (h >> 16);
        return d << 16 | 65535 & h
    }
    function h(c, a) {
        return c << a | c >>> 32 - a
    }
    function d(c, d, e, f, g, v) {
        return a(h(a(a(d, c), a(f, v)), g), e)
    }
    function e(c, a, h, e, f, g, v) {
        return d(a & h | ~a & e, c, a, f, g, v)
    }
    function f(c, a, h, e, f, g, v) {
        return d(a & e | h & ~e, c, a, f, g, v)
    }
    function g(c, a, h, e, f, g, v) {
        return d(a ^ h ^ e, c, a, f, g, v)
    }
    function v(c, a, h, e, f, g, v) {
        return d(h ^ (a | ~e), c, a, f, g, v)
    }
    function i(c, h) {
        c[h >> 5] |= 128 << h % 32,
        c[(h + 64 >>> 9 << 4) + 14] = h;
        var d, i, C, A, l, m = 1732584193,
        n = -271733879,
        o = -1732584194,
        p = 271733878;
        for (d = 0; d < c.length; d += 16) i = m,
        C = n,
        A = o,
        l = p,
        m = e(m, n, o, p, c[d], 7, -680876936),
        p = e(p, m, n, o, c[d + 1], 12, -389564586),
        o = e(o, p, m, n, c[d + 2], 17, 606105819),
        n = e(n, o, p, m, c[d + 3], 22, -1044525330),
        m = e(m, n, o, p, c[d + 4], 7, -176418897),
        p = e(p, m, n, o, c[d + 5], 12, 1200080426),
        o = e(o, p, m, n, c[d + 6], 17, -1473231341),
        n = e(n, o, p, m, c[d + 7], 22, -45705983),
        m = e(m, n, o, p, c[d + 8], 7, 1770035416),
        p = e(p, m, n, o, c[d + 9], 12, -1958414417),
        o = e(o, p, m, n, c[d + 10], 17, -42063),
        n = e(n, o, p, m, c[d + 11], 22, -1990404162),
        m = e(m, n, o, p, c[d + 12], 7, 1804603682),
        p = e(p, m, n, o, c[d + 13], 12, -40341101),
        o = e(o, p, m, n, c[d + 14], 17, -1502002290),
        n = e(n, o, p, m, c[d + 15], 22, 1236535329),
        m = f(m, n, o, p, c[d + 1], 5, -165796510),
        p = f(p, m, n, o, c[d + 6], 9, -1069501632),
        o = f(o, p, m, n, c[d + 11], 14, 643717713),
        n = f(n, o, p, m, c[d], 20, -373897302),
        m = f(m, n, o, p, c[d + 5], 5, -701558691),
        p = f(p, m, n, o, c[d + 10], 9, 38016083),
        o = f(o, p, m, n, c[d + 15], 14, -660478335),
        n = f(n, o, p, m, c[d + 4], 20, -405537848),
        m = f(m, n, o, p, c[d + 9], 5, 568446438),
        p = f(p, m, n, o, c[d + 14], 9, -1019803690),
        o = f(o, p, m, n, c[d + 3], 14, -187363961),
        n = f(n, o, p, m, c[d + 8], 20, 1163531501),
        m = f(m, n, o, p, c[d + 13], 5, -1444681467),
        p = f(p, m, n, o, c[d + 2], 9, -51403784),
        o = f(o, p, m, n, c[d + 7], 14, 1735328473),
        n = f(n, o, p, m, c[d + 12], 20, -1926607734),
        m = g(m, n, o, p, c[d + 5], 4, -378558),
        p = g(p, m, n, o, c[d + 8], 11, -2022574463),
        o = g(o, p, m, n, c[d + 11], 16, 1839030562),
        n = g(n, o, p, m, c[d + 14], 23, -35309556),
        m = g(m, n, o, p, c[d + 1], 4, -1530992060),
        p = g(p, m, n, o, c[d + 4], 11, 1272893353),
        o = g(o, p, m, n, c[d + 7], 16, -155497632),
        n = g(n, o, p, m, c[d + 10], 23, -1094730640),
        m = g(m, n, o, p, c[d + 13], 4, 681279174),
        p = g(p, m, n, o, c[d], 11, -358537222),
        o = g(o, p, m, n, c[d + 3], 16, -722521979),
        n = g(n, o, p, m, c[d + 6], 23, 76029189),
        m = g(m, n, o, p, c[d + 9], 4, -640364487),
        p = g(p, m, n, o, c[d + 12], 11, -421815835),
        o = g(o, p, m, n, c[d + 15], 16, 530742520),
        n = g(n, o, p, m, c[d + 2], 23, -995338651),
        m = v(m, n, o, p, c[d], 6, -198630844),
        p = v(p, m, n, o, c[d + 7], 10, 1126891415),
        o = v(o, p, m, n, c[d + 14], 15, -1416354905),
        n = v(n, o, p, m, c[d + 5], 21, -57434055),
        m = v(m, n, o, p, c[d + 12], 6, 1700485571),
        p = v(p, m, n, o, c[d + 3], 10, -1894986606),
        o = v(o, p, m, n, c[d + 10], 15, -1051523),
        n = v(n, o, p, m, c[d + 1], 21, -2054922799),
        m = v(m, n, o, p, c[d + 8], 6, 1873313359),
        p = v(p, m, n, o, c[d + 15], 10, -30611744),
        o = v(o, p, m, n, c[d + 6], 15, -1560198380),
        n = v(n, o, p, m, c[d + 13], 21, 1309151649),
        m = v(m, n, o, p, c[d + 4], 6, -145523070),
        p = v(p, m, n, o, c[d + 11], 10, -1120210379),
        o = v(o, p, m, n, c[d + 2], 15, 718787259),
        n = v(n, o, p, m, c[d + 9], 21, -343485551),
        m = a(m, i),
        n = a(n, C),
        o = a(o, A),
        p = a(p, l);
        return [m, n, o, p]
    }
    function C(c) {
        var a, h = "";
        for (a = 0; a < 32 * c.length; a += 8) h += String.fromCharCode(c[a >> 5] >>> a % 32 & 255);
        return h
    }
    function A(c) {
        var a, h = [];
        for (h[(c.length >> 2) - 1] = void 0, a = 0; a < h.length; a += 1) h[a] = 0;
        for (a = 0; a < 8 * c.length; a += 8) h[a >> 5] |= (255 & c.charCodeAt(a / 8)) << a % 32;
        return h
    }
    function l(c) {
        return C(i(A(c), 8 * c.length))
    }
    function m(c, a) {
        var h, d, e = A(c),
        f = [],
        g = [];
        for (f[15] = g[15] = void 0, e.length > 16 && (e = i(e, 8 * c.length)), h = 0; 16 > h; h += 1) f[h] = 909522486 ^ e[h],
        g[h] = 1549556828 ^ e[h];
        return d = i(f.concat(A(a)), 512 + 8 * a.length),
        C(i(g.concat(d), 640))
    }
    function n(c) {
        var a, h, d = "0123456789abcdef",
        e = "";
        for (h = 0; h < c.length; h += 1) a = c.charCodeAt(h),
        e += d.charAt(a >>> 4 & 15) + d.charAt(15 & a);
        return e
    }
    function o(c) {
        return unescape(encodeURIComponent(c))
    }
    function p(c) {
        return l(o(c))
    }
    function q(c) {
        return n(p(c))
    }
    function r(c, a) {
        return m(o(c), o(a))
    }
    function s(c, a) {
        return n(r(c, a))
    }
    function t(c, a, h) {
        return a ? h ? r(a, c) : s(a, c) : h ? p(c) : q(c)
    }
    "function" == typeof define && define.amd ? define("common/widgets/passport/dep/md5/md5", ["require"],
    function() {
        return t
    }) : c.md5 = t
} (this);