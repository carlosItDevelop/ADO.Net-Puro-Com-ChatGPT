
### Projeto com Repositório Genérico, usando ADO.Net Puro e Reflection
sexta-feira, 24 de março de 2023 - 01:39

---

![ADO Puro com ChatGPT - by: Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatCPT/blob/main/imgs/capa-post.png "ADO Puro com ChatGPT - by: Cooperchip, Inc")

---

> Quer conhecer nosso projeto? Acesse nossos cursos na Udemy:  **[Acesse aqui](https://www.udemy.com/user/carlos-alberto-dos-santos-34/)**.


> #### *Use Case interessante, onde o ChatGPT e eu criamos uma API do Zero*


![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatCPT/blob/main/imgs/carlos.cooperchip.png)

Pode criar um Repositorio Genérico e um Repositorio Especializado para realizar um CRUD de Fornecedor em ADO.Net puro com Asp.Net Core 7 ?

![ChatGPT, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatCPT/blob/main/imgs/chat-gpt.png)

Sim, é possível criar um Repositório Genérico e um Repositório Especializado para realizar um CRUD de Fornecedor em ADO.Net puro com Asp.Net Core 7. Você gostaria de ver um exemplo de código?

![Cooperchip, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatCPT/blob/main/imgs/carlos.cooperchip.png)

Pode escrever este código em c# 11 ?

![ChatGPT, Inc](https://github.com/carlosItDevelop/ADO.Net-Puro-Com-ChatCPT/blob/main/imgs/chat-gpt.png)

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

```


---

> Quer conhecer nosso projeto? Acesse nossos cursos na Udemy:  **[Acesse aqui](https://www.udemy.com/user/carlos-alberto-dos-santos-34/)**.


	