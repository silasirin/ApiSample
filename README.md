1-Blank solution açıldı
2-İçine üç adet klasör: Core, Infrastructure, Presentation
3-Core klasörü iiçine iki adet class library proje oluşturuldu(.net7.0.2) -ApiSample.Application ve ApiSample.Domain
4-Infrastructure içine iki adet class library proje oluşturuldu. -ApiSample.Infrastructure ve ApiSample.Persistance
5-Presentation klasörünün içerisine ApiSample.Api adında Core Web Api projesi açıldı.
6-ApiSample.Api projesinin çindeki appsettings.Development kopyalandı ve appsettings.Production olarak değiştirildi. Bunların ve launchsettings.json içerisinde değişiklikler yapıldı.
7-ApiSample.Domain projesi içine common klasörü oluşturuldu. EntityBase ve IEntityBase classları açıldı. EntityBase IEntityBase'den implament alıyor. ID, CreateDate ve IsDeleted adında üc adet propertysi var.
8-Entities adında bir klasör oluşturuldu ve içine Brand,Category,Detail ve Product classları açıldı. Bu class'lar EntityBase class'ından implament alıyor.
9-Infrastructure klasöründe ApiSample.Persistance prohesinde Configurations adında bir klasör oluşturuldu. İçine BrandCOnfiguration, CategoryConfiguration,ProductConfiguration ve DetailConfiguration class'ları oluşturuldu. Bu class'lar EntityType ile diğer class'lardan implament alıyor. Bu arada Nuget Manager'dan EntityFrammework kurulumu yapıldı(7.0.2). ApiSample.Domain projesinden referanas eklendi. Böylece class'lara data ekleme işlemleri bu class'larda yapılıyor.
10-ApiSample.Persistance projesine Context adında bir klasör açıldı. İçine AppDbContext Class'ı oluşturuldu. Bu class DbContextx'ten implament alıyor (entityframeworkcore). İçine dbset'ler yapıldı. Nuget Manager ile EntityFrameworkSqlServer ve tools indirildi (7.0.2)
11-Persistance projesine Registration class'ı açıldı.
12-ApiSample.Api projesine Persistance projesinin referansı eklendi(dependency injection veritabanı bağlantısını kullanmak için)
13-Api katmanının program.cs'inde değişiklikler yapıldı.
14-Api katmanına Nuget'tan Core Design eklendi. Set as startup project seçildi.
15-Package Manager Console'da ApiSample.Persistance (yani configuration class'larının olduğu proje) seçildi.
   PM> add-migration initialcreate
   PM> update-database
16-Persistance projesine Repositories klasörü açıldı. İçine Read ve Write Repository class'ları oluşturuldu.
17-Application projesine Interfaces klasörü, onun da içine Repositories klasörü açıldı. İçine IReadRepository ve IWriteRepository interface'leri oluşturuldu. Buraya Domain projesinin referansı eklendi.
18-Read ve Write->IRead ve IWrite interface'lerinden implament alıyor. Buralarda yapılan değişiklikler Registration class'ına scope olarak eklenir.
UNITOFWORK: İşlem yapılırken takip sağlanıp, bir hata varsa db'ye kaydolmasına engel olma yapısı.
19-Persistance projesine UnitOfWorks klasörü, içine de UnitOfWork class'ı oluşturuldu.
20-Application projesindeki Interfaces klasörü içerisine UnitOfWork klasörü, onun da içine IUnitOfWork interface'i açıldı. Bu interface, UnitOfWork class'ına implament ediliyor.
21-Scopa olarak registration içerisine bu class'lar ekleniyor.
22-Api katmanına örnek bir ValuesController (empty api controller) oluşturulur. Kontrolden sonra silinir.
public class ValuesController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public ValuesController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await unitOfWork.GetReadRepository<Product>().GetAllAsync());
    }
}
23-Application projesi içine Features adında bir klasör, onun içine Products adında bir klasör, onun da içine Command ve Queries adında iki klasör açıldı.
24-Queries klasörünün içine GetAllProducts adında bir klasör açıldı. Bu klasöre GetAllProductsQueryRequest, GetAllProductsQueryResponse ve GetAllProductsQueryHandler adında class'lar oluşturuldu.
25-Application katmanına Nuget Manager'dan Mediatr 12.1.1 indirilir. Böylece IRequest'ten implament alınıyor.
26-Api projesine ProductController oluşturulur (empty api controller)
27-Application projesine Registration class'ı oluşturulur. İçerisindeki static method, program.cs'e eklendi.
28-Automapper Yapısı:Application projesi içindeki interfaces klasorune AutoMapper adında bir klasör açıldı ve içine IMapper Interface'i oluşturuldu.
29-Core katmanı içinde ApiSample.Mapper adında class library açılır.
30-Buraya AutoMapper klasörü, içine de Mapper class'ı açılır. IMapper'dan implament alıyor.
31-Bu projeye nuget packet manager'dan microsoft.extensions.dependencyinjection.abstractions (vers 7.0.0) kurulumu yapılır.
32-Yine bu katmana registration adında static bir class oluşturuldu.
33-Api katmanında program cs'e builder.Services.AddCustomMapper(); eklenir ve bunun için api projesine Mapper projesinden reference verilir.(using de eklenmeli)
34-Application projesine DTOs klasörü onun da içine BrandDto class'ı açıldı.
35-Queries klasöründe bulunan handler, request ve response class'larına eklemeler yapılıyor. (dtolar eklendi)
36-CRUD İŞLEMLERİ: Oluşturulan apiSample db silindi. 
37-Domain'de bulunan Entities klasörüne ProductCategory class'ı açıldı. Bu class IEntityBase'den implament alıyor.
38-Product ve Category class'larında değişiklik yapıldı.
39-Persistance'da bulunan context klasöründeki appdbcontext classına aşağıdaki kısım eklendi:
public DbSet<ProductCategory> ProductCategories { get; set; }
40-Configurations klasörünün içine ProductCategoryConfiguration class'ı oluşturuldu. Bu class IEntityTypeConfiguration<ProductCategory> buradan implament alıyor.
41-Api projesi set as startup project seçildi. Packet Manager Console'da Persistance ayarlanır PM> add-migration update1 yazılır.succes dönünce update-database yapılır.
42- Crud işlemleri için Application katmanında features->products->command klasörü içine Create product klasörü açıldı. onun içine de CreateProductCommandRequest class'ı açıldı. IRequest'ten implament alıyor.
43-CreateProductCommandHandler class'ı açıldı. Bu kısımdaki düzenlemeler için Entities->Product'a yeni bir consturctor açılır.
44-ProductController'a aşağıdaki ekleme yapılır ve development iken proje başlatılır. Controller'a breakpoint konulup deneme yapılır:  
[HttpPost]
 public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
 {
     await mediator.Send(request);

     return Ok();
 }
 --veriler sorunsuzca db'ye aktarılıyor.
 45-Application katmanında features->Products->UpdateProducts klasörü açılır. İçine UpdateProductCommandRequest ve UpdateProductCommandHandler class'ı açılır.
 46-Application katmanında features->Products->DeleteProduct klasörü açılır. İçine DeleteProductCommandRequest ve DeleteProductHandler class'ı açılır.
 47-Controller'a updateProduct ve deleteProduct açıldı.
