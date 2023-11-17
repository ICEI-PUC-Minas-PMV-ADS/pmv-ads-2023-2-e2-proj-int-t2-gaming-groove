# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

Implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos com os artefatos criados (código fonte), deverão apresentadas as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

Por exemplo: a tabela a seguir deverá ser preenchida considerando os artefatos desenvolvidos.

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-001| A plataforma deve permitir que o usuário se cadastre. | UsuarioController.cs / UsuarioModel.cs / (Login)Index.cshtml/ (HomePage)Index.cshtml | 
|RF-002| A plataforma deve permitir que o usuário faça login. | LoginController.cs / UsuarioModel.cs / (Login)Index.cshtml/ (HomePage)Index.cshtml |
|RF-003| A plataforma deve possuir um sistema de chat.| ChatController.cs / ChatModel.cs |
|RF-004| A plataforma deve possuir um sistema de comunidades. | ComunidadeController.cs / ComunidadeModel.cs | 
|RF-005| A plataforma deve possuir um sistema que permita que o usuário realize publicações. | PublicacaoController.cs / PublicacaoModel.cs / ComunidadeModel.cs / FeedPage.cs | 
|RF-006| A plataforma deve possuir um sistema de formação de equipes e gerenciamento de membros. | EquipeController.cs / EquipeModel.cs / EquipePage.cshtml | 
|RF-007| A plataforma deve conter uma ferramenta para adicionar, remover ou bloquear usuários.| AmizadeController.cs / AmizadeModel.cs | 
|RF-008| A plataforma deve conter uma ferramenta de pesquisa de usuários ou comunidades. | UsuarioController.cs / ComunidadeController.cs / UsuarioModel.cs / ComunidadeModel.cs | 
|RF-009| A plataforma deve conter uma ferramenta para denunciar usuários, comunidades e postagens. | DenunciaController / DenunciaModel.cs | 
|RF-010| A plataforma deve permitir que cada usuário possua uma página de perfil editável. | PerfilPageController.cs / LoginControler.cs / UsuarioModel.cs / PerfilPage.cshtml | 


# Instruções de acesso

Não deixe de informar o link onde a aplicação estiver disponível para acesso (por exemplo: https://adota-pet.herokuapp.com/src/index.html).

Se houver usuário de teste, o login e a senha também deverão ser informados aqui (por exemplo: usuário - admin / senha - admin).

O link e o usuário/senha descritos acima são apenas exemplos de como tais informações deverão ser apresentadas.

> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
