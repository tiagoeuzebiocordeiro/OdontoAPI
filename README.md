# OdontoAPI

Versão da API: v1.0
Esse projeto consite em uma API RESTful para um gerenciamento de clínicas odontológicas. Cadastro, Gerenciamento, Edição e Deleção de dentistas, pacientes e consultas.

## Principais funções e características
Essa API fornece diversas funcionalidades e informações, como:

- Dentistas: nome, código de CRO, especialidade, endereço, telefone, CPF, email, data de nascimento, sexo, turno do dentista, status (ativo ou inativo), data do cadastro e data de modificação.
- Pacientes: nome, data de nascimento, CPF, endereço, telefone, email, sexo, status, data de cadastro e data de modificação.
- Consultas: dentista associado, paciente associado (ambos por id), data da consulta, data de cadastro da consulta (no banco de dados) e data de modificação da consulta.

Em ambas entidades, os atributos data de cadastro e data de modificação são gerenciados pelo banco de dados, através de um TRIGGER AFTER UPDATE. Ou seja, cuidado ao manusear os endpoints. Para mais informações do banco de dados, consulte a pasta SQL, dentro do projeto. Nessa pasta possui um backup do schema
do banco, lá, você pode rodar uma stored procedure e entender como foi feito o trigger.

Este projeto foi desenvolvido utilizando a orientação Database First.

## Padrão de projeto
Este projeto foi desenvolvido utilizando o REPOSITORY PATTERN. Separando assim, toda lógica do controller, colocando apenas no Service, que, por sua vez, obedece a interface de implementação. Consulte o código para mais informações.

## Tecnologias
- API: em .NET 6.0 com Entity Framework.
- Swagger: Ferramenta para documentação.
- Banco de dados: SQL Server.
- NuGets: Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools, Swashbucke.AspNetCore, Swashbuckle.AspNetCore.Annotations

## Segurança
Este projeto não possui autenticação com JWT ou vertentes. Será uma atualização futura.

## Endpoints
Cuidado com seu manuseio! Consulte a seção de principais funções e leia atentamente sobre os atributos.
* Para dentistas:
- /api/Dentista (GET) = consulta todos os dentistas presentes cadastrados no banco de dados.
- /api/Dentista (POST) = cadastra um dentista para o banco de dados. Retornando depois uma lista de todos os dentistas presentes no banco, caso tenha.
- /api/Dentista (PUT) = atualiza um dentista presente no banco de dados, baseado em receber um objeto completo com Id no corpo da requisição. Retornando depois uma lista de todos os dentistas presentes no banco, caso tenha. Lembrando: após cadastrar, a data de alteração e criação devem estar "bugadas", mas, é só atualizar e dar um GET todos para obter os dados corretos.
- /api/Dentista/{id} (GET) = consulta um dentista presente no banco de dados baseado por Id.
- /api/Dentista/{id} (DELETE) = deleta um dentista por Id. Retornando depois uma lista de todos os dentistas presentes no banco, caso tenha.
- api/Dentista/inativaStatusDentista/{id} (PUT) = inativa um dentista presente no banco de dados. Retornando depois uma lista de todos os dentistas presentes no banco, caso tenha.

* Para pacientes:
- /api/Paciente (GET) = consulta todos os pacientes presentes cadastrados no banco de dados.
- /api/Paciente (POST) = cadastra um paciente para o banco de dados. Retornando depois uma lista de todos os pacientes presentes no banco, caso tenha.
- /api/Paciente (PUT) = atualiza um paciente presente no banco de dados, baseado em receber um objeto completo com Id no corpo da requisição. Retornando depois uma lista de todos os pacientes presentes no banco, caso tenha. Lembrando: após cadastrar, a data de alteração e criação devem estar "bugadas", mas, é só atualizar e dar um GET todos para obter os dados corretos.
- /api/Paciente/{id} (GET) = consulta um paciente presente no banco de dados baseado por Id.
- /api/Paciente/{id} (DELETE) = deleta um paciente por Id. Retornando depois uma lista de todos os paciente presentes no banco, caso tenha.
- api/Paciente/inativaStatusPaciente/{id} (PUT) = inativa um paciente presente no banco de dados. Retornando depois uma lista de todos os pacientes presentes no banco, caso tenha.

* Para consultas:
- /api/Consulta (GET) = consulta todas as consultas presentes cadastrados no banco de dados.
- /api/Consulta (POST) = cadastra uma consulta para o banco de dados. Retornando depois uma lista de todos as consultas presentes no banco, caso tenha. OBS: para cadastro de uma consulta, é necessário possuir pelo menos UM dentista e UM paciente cadastrado no banco de dados, pois será feito a associação por Id no corpo da requisição. Lembrando: após cadastrar, a data de alteração e criação devem estar "bugadas", mas, é só atualizar e dar um GET todos para obter os dados corretos.
- /api/Consulta (PUT) = atualiza uma consulta presente no banco de dados, baseado em receber um objeto completo com Id no corpo da requisição. Retornando depois uma lista de todas as consultas presentes no banco, caso tenha.
- /api/Consulta/{id} (GET) = realiza uma consulta para pesquisa de uma consulta específica presente no banco de dados baseado por Id.
- /api/Consulta/{id} (DELETE) = deleta uma consulta por Id. Retornando depois uma lista de todas as consultas presentes no banco, caso tenha.

PROBLEMA: se eu faço um update de uma consulta existente, ele reseta a data_cadastro.
