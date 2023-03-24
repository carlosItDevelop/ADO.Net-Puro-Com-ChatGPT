
### Projeto com Repositório Genérico, usando ADO.Net Puro e Reflection
sexta-feira, 24 de março de 2023 - 01:39

> #### **Use Case interessante, onde o ChatGPT e eu criamos uma API do Zero**

---

![ADO Puro com ChatGPT - by: Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatCPT/blob/main/imgs/capa-post.png "ADO Puro com ChatGPT - by: Cooperchip, Inc")

---

> Quer conhecer nosso projeto? Acesse nossos cursos na Udemy:  **[Acesse aqui](https://www.udemy.com/user/carlos-alberto-dos-santos-34/)**.

---

![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/poeta-a-esquerda.png)

Pode criar um Repositorio Genérico e um Repositorio Especializado para realizar um CRUD de Fornecedor em ADO.Net puro com Asp.Net Core 7 ?

![ChatGPT, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/chat-gpt-a-esquerda.png)

Sim, é possível criar um Repositório Genérico e um Repositório Especializado para realizar um CRUD de Fornecedor em ADO.Net puro com Asp.Net Core 7. Você gostaria de ver um exemplo de código?

![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/poeta-a-esquerda.png)

Pode escrever este código em c# 11 ?

![ChatGPT, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/chat-gpt-a-esquerda.png)

Sim, é possível escrever o código em C# 11. Aqui está um exemplo de como um Repositório Genérico e um Repositório Especializado para realizar um CRUD de Fornecedor em ADO.Net puro com Asp.Net Core 7 pode ser implementado em C# 11:

```csharp

public interface IRepository<T> where T: class{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

public class Repository<T> : IRepository<T> where T: class
{
    private readonly string _connectionString;
    public Repository(string connectionString)
   {
        _connectionString = connectionString;
   }

public async Task<IEnumerable<T>> GetAllAsync()
{
        // Implementação do método para retornar todos os registros da tabela
        throw new NotImplementedException();
}
public asyncTask<T> GetByIdAsync(int id){
        // Implementação do método para retornar um registro pelo ID
        throw new NotImplementedException();
}
public asyncTask AddAsync(T entity){
        // Implementação do método para adicionar um novo registro na tabela
        throw new NotImplementedException();
}
public async Task UpdateAsync(T entity){
        // Implementação do método para atualizar um registro existente na tabela
        throw new NotImplementedException();
}

[HttpPost]
public asyncTask<IActionResult> Add(Fornecedor fornecedor)
{
    await  _repository.AddAsync(fornecedor);
    return CreatedAtAction(nameof(GetById), new{ id = fornecedor.Id }, fornecedor);
}

[HttpPut("{id}")]
public async Task<IActionResult> Update(intid, Fornecedor fornecedor)
{
    if(id != fornecedor.Id) return BadRequest();
    await _repository.UpdateAsync(fornecedor);
    return NoContent();
}

[HttpDelete("{id}")]
public asyncTask<IActionResult> Delete(int id)
{
    await _repository.DeleteAsync(id);
    return NoContent();
}

```

Este é um exemplo de como uma Controller pode ser criada em C# para consumir o Repositório Genérico que implementamos acima com o Modelo Fornecedor. 

A Controller possui métodos para realizar operações CRUD na tabela de Fornecedores usando o Repositório Genérico. 

É importante notar que este é apenas um exemplo e pode ser adaptado e melhorado de acordo com as necessidades específicas do projeto.

![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/poeta-a-esquerda.png)

Escreva o código para configuramos e conectarmos um Banco de Dados SQl Server para nosso exemplo acima.

![ChatGPT, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/chat-gpt-a-esquerda.png)

Claro! 
Aqui está um exemplo de como podemos configurar e conectar um Banco de Dados SQL Server para nosso exemplo acima em C# com Asp.Net Core 7:

Primeiro, precisamos adicionar a string de conexão com o banco de dados no arquivo appsettings.json:

```json

{
  "ConnectionStrings":
           {
                  "DefaultConnection":"Server=(localdb)\\mssqllocaldb;Database=MeuBancoDeDados;Trusted_Connection=True;"
	}
}

```

Em seguida, precisamos configurar o serviço do Repositório Genérico no método ConfigureServices da classe Startup:

```csharp

public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.Configure<ConnectionStringOptions>(Configuration.GetSection("ConnectionStrings"));
}
```

Também precisamos criar uma classe ConnectionStringOptions para armazenar a string de conexão:

```csharp

public class ConnectionStringOptions{
    public string DefaultConnection { get; set; }
}
```

E por fim, precisamos modificar o construtor da classe Repository<T> para receber a string de conexão através do serviço de opções do Asp.Net Core:

```csharp

private readonly string _connectionString;

public Repository(IOptions<ConnectionStringOptions> options)
{
    _connectionString = options.Value.DefaultConnection;
}
```

Com estas alterações, estamos prontos para conectar nosso exemplo acima com um Banco de Dados SQL Server. 

É importante notar que este é apenas um exemplo e pode ser adaptado e melhorado de acordo com as necessidades específicas do projeto.

![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/poeta-a-esquerda.png)

Precisamos de uma classe de contexto neste caso ou não?

![ChatGPT, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/chat-gpt-a-esquerda.png)

Não, neste caso não precisamos de uma classe de contexto. Estamos usando ADO.Net puro para realizar operações CRUD na tabela e não estamos usando um ORM (Object-Relational Mapping) como o Entity Framework Core que requer uma classe de contexto para gerenciar o acesso ao banco de dados.
A classe de contexto é usada pelo Entity Framework Core para gerenciar o acesso ao banco de dados e mapear as entidades do modelo para as tabelas do banco de dados. 

Como estamos usando ADO.Net puro e escrevendo os comandos SQL diretamente nos métodos do Repositório Genérico, não precisamos de uma classe de contexto neste caso.


![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/poeta-a-esquerda.png)

```csharp

// ToDo: => Para projeto sem a Startup ...
```

O meu projeto está na versão 7 do Asp.Net Core, portanto não tem a classe Startup.cs. 
- Como eu faço para configurar o código abaixo na classe Program.cs ? 

```csharp

public void ConfigureServices(IServiceCollection services) 
{ 
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 
    services.Configure<ConnectionStringOptions>(Configuration.GetSection("ConnectionStrings")); 
}
```

![ChatGPT, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/chat-gpt-a-esquerda.png)

Se você está usando a versão 7 do Asp.Net Core, pode configurar os serviços no método Main da classe Program.cs usando o método ConfigureServices do objeto WebApplication. 

Aqui está um exemplo de como você pode fazer isso:

```csharp
public static voidMain(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    app.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    app.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection("ConnectionStrings"));
	// ...
}
```

Neste exemplo, estamos usando o método ConfigureServices do objeto WebApplication para adicionar os serviços do Repositório Genérico e configurar as opções de string de conexão com o banco de dados. 

É importante notar que este é apenas um exemplo e pode ser adaptado e melhorado de acordo com as necessidades específicas do projeto.


![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatGPT/blob/main/imgs/poeta-a-esquerda.png)

Estou com problemas para inserir um novo Fornecedor, pois não quero informar o Id na Inserção de Registro. Segue o código que você mesmo gerou:

img-codigo-1



---

> Quer conhecer nosso projeto? Acesse nossos cursos na Udemy:  **[Acesse aqui](https://www.udemy.com/user/carlos-alberto-dos-santos-34/)**.


	