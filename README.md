# AluraDotNetCleanArchitecture
Projeto feito para praticar conceitos do Clean  Architecture aprendidos durante o curso https://cursos.alura.com.br/course/arquitetura-dotnet-descomplicando-clean-architecture

## Domínio

A documentação do domínio (jornada, subdomínios, premissas e glossário) está em [docs/dominio.md](docs/dominio.md).

## Migrations

Execute na pasta da solução, trocando `NomeDaMigration` pelo nome desejado (a primeira costuma ser `InitialCreate`):

```bash
dotnet ef migrations add NomeDaMigration --project ScheduleAPI.Infrastructure --startup-project ScheduleAPI
dotnet ef database update --project ScheduleAPI.Infrastructure --startup-project ScheduleAPI
```
