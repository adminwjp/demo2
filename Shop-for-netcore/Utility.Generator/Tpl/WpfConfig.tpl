            CacheListModelManager.CacheFlagMethod["Config.{.class}"] = new MethodTemplateEntry()
            {
                Add = (it) =>
                {
                    {.class}ViewModel {.class}View = ({.class}ViewModel)it;
                    Create{.class}Input create{.class}= objectMapper.Map<Create{.class}Input>({.class}View);
                    {.class}AppService {.class}App = StartManager.serviceProvider.GetService<{.class}AppService>();
                    {.class}App.Insert(create{.class});
                    return  1;
                },
                Modify = (it) =>
                {
                   {.class}ViewModel {.class}View = ({.class}ViewModel)it;
                    Update{.class}Input create{.class} = objectMapper.Map<Update{.class}Input>({.class}View);
                    {.class}AppService {.class}App = StartManager.serviceProvider.GetService<{.class}AppService>();
                    {.class}App.Update(create{.class});
                },
                Delete = (it) =>
                {
                    {.class}ViewModel {.class}View = ({.class}ViewModel)it;
                    {.class}AppService {.class}App = StartManager.serviceProvider.GetService<{.class}AppService>();
                    {.class}App.Delete({.class}View.Id);
                },
                DeleteList = (it) =>
                {
                    {.class}ViewModel[] {.class}Views = ({.class}ViewModel[])it;
                    List<long?> ids = {.class}Views.Select(it1 => it1.Id).ToList();
                    {.class}AppService {.class}App = StartManager.serviceProvider.GetService<{.class}AppService>();
                    {.class}App.Delete(ids);
                },
                 FindList= (page, size) =>
                { 
                    {.class}AppService {.class}App = StartManager.serviceProvider.GetService<{.class}AppService>();
                    var data= {.class}App.Find( page, size);
                    var result= objectMapper.Map<List<{.class}ViewModel>>(data);
                    return result;
                },
                FindListByWhere = (it, page, size) =>
                {
                    {.class}AppService {.class}App = StartManager.serviceProvider.GetService<{.class}AppService>();
                    if (it == null)
                    {
                        {.class}ViewModel {.class}View = ({.class}ViewModel)it;
                        Query{.class}Input query{.class} = objectMapper.Map<Query{.class}Input>({.class}View);
                        var data= {.class}App.Find(query{.class},  page, size);
                        var result= objectMapper.Map<List<{.class}ViewModel>>(data);
                        return result;
                    }
                   else{
                        var data= {.class}App.Find(new Query{.class}Input(), page, size);
                        var result= objectMapper.Map<List<{.class}ViewModel>>(data);
                        return result;
                   }
                },
            };