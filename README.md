# Financial Trading Data Processing Service
Este é um serviço de processamento de dados em tempo real para uma plataforma de negociação financeira. O serviço recebe dados de mercado via uma conexão TCP, realiza cálculos e retorna os dados processados para o cliente. O processamento de dados é essencial para a tomada de decisões de negociação, portanto, é necessário que seja rápido e eficiente.

## Visão Geral do Projeto

### Servidor TCP
- Implementa um servidor TCP em C# que escuta em uma porta específica.
- O servidor aceita pacotes de dados contendo informações do mercado (timestamp, intervalo, símbolo do estoque, preço de abertura, - preço de fechamento, volume).
- Processa os dados, calculando médias móveis simples (SMA) e Convergência e Divergência de Médias Móveis (MACD) usando multithreading para garantir desempenho.
- Responde ao cliente com os dados processados.

### Requisitos Técnicos
- Utiliza C# e .NET 8.0.
- Configura pipelines de CI/CD no GitHub Actions para compilação, execução de testes unitários e distribuição.
- Escreve testes unitários para a lógica de processamento de dados para garantir precisão e robustez.
- Containeriza o aplicativo do servidor TCP usando Docker, fornecendo um Dockerfile e instruções para construir e executar o contêiner.
- Implementa logging na aplicação para rastrear operações e erros, juntamente com monitoramento básico para observar o desempenho (tempo de resposta, throughput).

## Estrutura do Projeto
```
/
│   ├── TCPServer.cs              # Implementação do servidor TCP
│   └── ...
├── tests/
│   ├── TCPServerTests.cs         # Testes unitários para a lógica de processamento de dados
│   └── ...
├── Dockerfile                    # Arquivo Docker para containerizar o aplicativo
├── README.md                     # Este arquivo
└── ...
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

4. ### Construir e Executar o Contêiner Docker:
```
docker build -t tcp-server .
docker run -p 8080:8080 tcp-server
```

