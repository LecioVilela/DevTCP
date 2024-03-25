# Financial Trading Data Processing Service
Este � um servi�o de processamento de dados em tempo real para uma plataforma de negocia��o financeira. O servi�o recebe dados de mercado via uma conex�o TCP, realiza c�lculos e retorna os dados processados para o cliente. O processamento de dados � essencial para a tomada de decis�es de negocia��o, portanto, � necess�rio que seja r�pido e eficiente.

## Vis�o Geral do Projeto

### Servidor TCP
- Implementa um servidor TCP em C# que escuta em uma porta espec�fica.
- O servidor aceita pacotes de dados contendo informa��es do mercado (timestamp, intervalo, s�mbolo do estoque, pre�o de abertura, - pre�o de fechamento, volume).
- Processa os dados, calculando m�dias m�veis simples (SMA) e Converg�ncia e Diverg�ncia de M�dias M�veis (MACD) usando multithreading para garantir desempenho.
- Responde ao cliente com os dados processados.

### Requisitos T�cnicos
- Utiliza C# e .NET 8.0.
- Configura pipelines de CI/CD no GitHub Actions para compila��o, execu��o de testes unit�rios e distribui��o.
- Escreve testes unit�rios para a l�gica de processamento de dados para garantir precis�o e robustez.
- Containeriza o aplicativo do servidor TCP usando Docker, fornecendo um Dockerfile e instru��es para construir e executar o cont�iner.
- Implementa logging na aplica��o para rastrear opera��es e erros, juntamente com monitoramento b�sico para observar o desempenho (tempo de resposta, throughput).

## Estrutura do Projeto
```
/
?   ??? TCPServer.cs              # Implementa��o do servidor TCP
?   ??? ...
??? tests/
?   ??? TCPServerTests.cs         # Testes unit�rios para a l�gica de processamento de dados
?   ??? ...
??? Dockerfile                    # Arquivo Docker para containerizar o aplicativo
??? README.md                     # Este arquivo
??? ...
```

## Utilizacao
1. ### Clonar o repositorio:
```
git clone https://github.com/LecioVilela/DevTCP.git
```

2. ### Executar o servidor:
```
dotnet run --project TCPServer.csproj
```

3. ### Executar testes:
```
dotnet test tests/TCPServerTests.csproj
```

4. ### Construir e Executar o Cont�iner Docker:
```
docker build -t tcp-server .
docker run -p 8080:8080 tcp-server
```

