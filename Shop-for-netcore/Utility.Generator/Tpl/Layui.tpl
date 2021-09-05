
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>{.title}</title>
    <meta name="renderer" content="webkit">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="format-detection" content="telephone=no">
    <link rel="stylesheet" href="/plugin/layui/2.6.8/css/layui.css" media="all" />
    <link rel="stylesheet" href="/plugin/layui/2.6.8/font/font_tnyc012u2rlwstt9.css" media="all" />
    <!-- <link rel="stylesheet" href="//at.alicdn.com/t/font_tnyc012u2rlwstt9.css" media="all" />-->
     <!--<link rel="stylesheet" href="/css/treetable.css" />-->
</head>
<body class="childrenBody">
   <blockquote class="layui-elem-quote news_search toolList" id="menus">
</blockquote>

<div class="layui-row">
    <div class="layui-tab">
        <ul class="layui-tab-title identityResource_tabs" id="identityResource_tabs">
            <li class="layui-this" data-type="identityResources">��֤��Դ����</li>
            <li data-type="identityResourceClaims">��֤��ԴClaim����</li>
            <li data-type="identityResourceProperties">��֤��ԴProperty����</li>
        </ul>
        <div class="layui-tab-content identityResource_clildFrame">

            <div class="layui-tab-item layui-show">
                <div class="layui-col-xs12">
                    <table class="layui-table"
                           lay-data="{height: 'full-80', page:true, id:'identityResources'}"
                           lay-filter="identityResources" id="identityResources" lay-size="sm">
                        <thead>
                            <tr>
                                <th lay-data="{checkbox:true, fixed: true}"></th>
                                <th lay-data="{field:'id', width:180}">ID</th>
                                <th lay-data="{field:'enabled', width:150, sort: true}">Enabled</th>
                                <th lay-data="{field:'name', width:150}">Name</th>
                                <th lay-data="{field:'display_name', width:135}">DisplayName</th>
                                <th lay-data="{field:'description', width:180}">Description</th>
                                <th lay-data="{field:'required', width:180}">Required</th>
                                <th lay-data="{field:'emphasize', width:180}">Emphasize</th>
                                <th lay-data="{field:'show_in_discovery_document', width:180}">ShowInDiscoveryDocument</th>
                                <th lay-data="{field:'created', width:180}">Created</th>
                                <th lay-data="{field:'updated', width:180}">Updated</th>
                                <th lay-data="{field:'non_editable', width:180}">NonEditable</th>
                                <th lay-data="{fixed: 'right', width:200, align:'center', toolbar: '#barList'}"></th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>

            <div class="layui-tab-item">
                <div class="layui-col-xs12">
                    <table class="layui-hide" id="identityResourceClaims" lay-filter="identityResourceClaims">
                    </table>
                </div>
            </div>

            <div class="layui-tab-item">
                <div class="layui-col-xs12">
                    <table class="layui-hide" id="identityResourceProperties" lay-filter="identityResourceProperties">
                    </table>
                </div>
            </div>

        </div>
    </div>


</div>

<script type="text/html" id="barList">
    <a class="layui-btn layui-btn-primary layui-btn-xs" lay-event="detail">�鿴</a>
    <a class="layui-btn layui-btn-xs" lay-event="edit">�༭</a>
    <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="del">ɾ��</a>
</script>

<!--��֤��Դ���/�༭����/�鿴����-->
<div id="divEdit" style="display: none">
    <form class="layui-form layui-form-pane" action="" id="formEdit">

        <input type="hidden" name="id" v-model="id" />

        <div class="layui-form-item" pane>
            <label class="layui-form-label">�Ƿ����</label>
            <div class="layui-input-block">
                <input type="checkbox" name="enabled" v-model="enabled" lay-skin="switch" value="true">
            </div>
        </div>


        <div class="layui-form-item">
            <label class="layui-form-label">Name</label>
            <div class="layui-input-block">
                <input type="text" name="name" v-model="name" required lay-verify="required"
                       placeholder="������Name" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">DisplayName</label>
            <div class="layui-input-block">
                <input type="text" name="display_name" v-model="display_name" required lay-verify="required"
                       placeholder="������DisplayName" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">Description</label>
            <div class="layui-input-block">
                <input type="text" name="description" value="����һ����,ʲôҲû����!" v-model="description" required lay-verify="required"
                       placeholder="������Description" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">Required</label>
            <div class="layui-input-block">
                <input type="text" name="required" v-model="required"
                       placeholder="������Required" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">Emphasize</label>
            <div class="layui-input-block">
                <input type="text" name="emphasize" v-model="emphasize"
                       placeholder="������Emphasize" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">ShowInDiscoveryDocument</label>
            <div class="layui-input-block">
                <input type="text" name="show_in_discovery_document" v-model="show_in_discovery_document"
                       placeholder="������ShowInDiscoveryDocument" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">Created</label>
            <div class="layui-input-block">
                <input type="text" name="created" v-model="created"
                       placeholder="������Created" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">Updated</label>
            <div class="layui-input-block">
                <input type="text" name="updated" v-model="updated"
                       placeholder="������Updated" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">NonEditable</label>
            <div class="layui-input-block">
                <input type="text" name="non_editable" v-model="non_editable" required lay-verify="required"
                       placeholder="������NonEditable" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <div class="layui-input-block">
                <button class="layui-btn" lay-submit lay-filter="formSubmit">�����ύ</button>
                <button type="reset" class="layui-btn layui-btn-primary">����</button>
            </div>
        </div>
    </form>
</div>


<!--��֤��ԴClaim���/�༭����/�鿴����-->
<div id="divIdentityResourceClaimsEdit" style="display: none">
    <form class="layui-form layui-form-pane" action="" id="formIdentityResourceClaimsEdit">

        <input type="hidden" name="id" v-model="id" />

        <div class="layui-form-item">
            <label class="layui-form-label">Type</label>
            <div class="layui-input-block">
                <input type="text" name="type" v-model="type" required lay-verify="required"
                       placeholder="������Type" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">��֤��Դ����</label>
            <div class="layui-input-block">
                <select name="identity_resource_id" v-model="identity_resource_id" class="layui-input">
                    <option value="">---��ѡ����֤��Դ---</option>
                </select>
            </div>
        </div>

        <div class="layui-form-item">
            <div class="layui-input-block">
                <button class="layui-btn" lay-submit lay-filter="formSubmit">�����ύ</button>
                <button type="reset" class="layui-btn layui-btn-primary">����</button>
            </div>
        </div>
    </form>
</div>

<!--��֤��ԴProperty���/�༭����/�鿴����-->
<div id="divIdentityResourcePropertiesEdit" style="display: none">
    <form class="layui-form layui-form-pane" action="" id="formIdentityResourcePropertiesEdit">

        <input type="hidden" name="id" v-model="id" />

        <div class="layui-form-item">
            <label class="layui-form-label">Key</label>
            <div class="layui-input-block">
                <input type="text" name="key" v-model="key" required lay-verify="required"
                       placeholder="������Key" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">Value</label>
            <div class="layui-input-block">
                <input type="text" name="value" v-model="value" required lay-verify="required"
                       placeholder="������Value" autocomplete="off" class="layui-input">
            </div>
        </div>

        <div class="layui-form-item">
            <label class="layui-form-label">��֤��Դ����</label>
            <div class="layui-input-block">
                <select name="identity_resource_id" v-model="identity_resource_id" class="layui-input">
                    <option value="">---��ѡ����֤��Դ---</option>
                </select>
            </div>
        </div>

        <div class="layui-form-item">
            <div class="layui-input-block">
                <button class="layui-btn" lay-submit lay-filter="formSubmit">�����ύ</button>
                <button type="reset" class="layui-btn layui-btn-primary">����</button>
            </div>
        </div>
    </form>
</div>

<script type="text/javascript" src="/layui/layui.js"></script>
<script type="text/javascript" src="/js/global.js"></script>
<script>
    var options = {
        url: '/Admin/IdentityResource/Load',
        add: '/Admin/IdentityResource/Add',
        update: '/Admin/IdentityResource/Update',
        delete: '/Admin/IdentityResource/delete',
        id: 'identityResources',
        form: undefined,
        formId: undefined,
        menuName: 'identityResource',
        key: 'id',
        tabName: 'identityResource_tabs',
        many: true,
        tabs: {
            identityResources: {
                form: "#formEdit",
                formId: "#divEdit",
                reload: true,
                options: {
                    elem: '#identityResources'
                    , url: '/admin/IdentityResource/load',
                    id: 'identityResources'
                },
                table: undefined,
                initial: undefined,
                key: 'id',
                add: '/Admin/IdentityResource/Add',
                update: '/Admin/IdentityResource/Update',
                delete: '/Admin/IdentityResource/delete',
            },
            identityResourceClaims: {
                reload: false,
                form: "#formIdentityResourceClaimsEdit",
                formId: "#divIdentityResourceClaimsEdit",
                options: {
                    elem: '#identityResourceClaims',
                    id: 'identityResourceClaims'
                    , url: '/admin/IdentityResource/Claim'
                    , cols: [[
                        { type: 'checkbox', fixed: 'left' },
                        { field: 'identity_resource_id', width: 180, title: 'IdentityResourceId', sort: true }
                        , { field: 'id', width: 180, title: 'Id' }
                        , { field: 'type', width: 180, title: 'Type', sort: true }
                        , { fixed: 'right', width: 200, align: 'center', toolbar: '#barList' }
                    ]]
                },
                table: undefined,
                initial: undefined,
                key: 'id',
                add: '/Admin/IdentityResource/AddClaim',
                update: '/Admin/IdentityResource/UpdateClaim',
                delete: '/Admin/IdentityResource/deleteClaim'
            },
            identityResourceProperties: {
                reload: false,
                form: "#formIdentityResourcePropertiesEdit",
                formId: "#divIdentityResourcePropertiesEdit",
                options: {
                    elem: '#identityResourceProperties',
                    id: 'identityResourceProperties'
                    , url: '/admin/IdentityResource/Property'
                    , cols: [[
                        { type: 'checkbox', fixed: 'left' },
                        { field: 'key', width: 180, title: 'ClientIdKey', sort: true }
                        , { field: 'id', width: 180, title: 'Id' }
                        , { field: 'identity_resource_id', width: 180, title: 'IdentityResourceId', sort: true }
                        , { field: 'value', width: 180, title: 'Value' }
                        , { fixed: 'right', width: 200, align: 'center', toolbar: '#barList' }
                    ]]
                },
                table: undefined,
                initial: undefined,
                key: 'id',
                add: '/Admin/IdentityResource/AddProperty',
                update: '/Admin/IdentityResource/UpdateProperty',
                delete: '/Admin/IdentityResource/deleteProperty'
            }
        }
    };

    initial(options);
</script>

</body>
</html>


