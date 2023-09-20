# Plano de Testes de Software

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

 
| **Caso de Teste** 	| **CT-01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-001 - Permitir que o usuário se cadastre e faça login.|
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	|<br>1- Acessar a página de boas vindas<br><br> 2- Clicar no botão "Cadastro"<br><br>3- Preencher os campos obrigatórios (Nome de usuário, nome completo, data de nascimento, E-mail, Senha e  confirmação de senha)<br><br>4- Clicar no botão "Criar conta"
|Critério de Êxito |  O cadastro foi realizado. |
|   |   |
| Caso de Teste   | **CT-02 – Realizar login** |
|Requisito Associado | RF-002 - A plataforma deve possuir um sistema de chat. |
| Objetivo do Teste   | Verificar se o usuário consegue logar na aplicação. |
| Passos  | 1- Acessar página de boas vindas  <br><br> 2- Clicar no botão "Login"<br><br> 3- Preencher o campo de e-mail <br><br> 4- Preencher o campo da senha<br><br>5- Checar se a senha está correta <br><br>6- Receber um alerta caso a senha for digitada errada.<br><br>7- Clicar em "Login"
|Critério de Êxito | - O login foi efetuado usuário consegue entrar na aplicação.|
| **Caso de Teste**   | **CT-03 – Iniciar conversa no chat** |
| Requisito Associado   | RF-002 - A plataforma deve possuir um sistema de chat. |
| Objetivo do Teste   | Verificar se os usuários conseguem conversar em tempo real. |
| Passos  | 1- Abrir lista de amigos <br><br>2- Selecionar amigo <br><br>3- Digitar mensagem<br><br>4- Enviar mensagem <br><br>5- Receber mensagem |
|Critério de Êxito | Mensagem enviadas e recebidas com sucesso. |
| **Caso de Teste**   | **CT-04 - Acessar comunidades** |
| Requisito Associado   | RF-003	A plataforma deve possuir um sistema de comunidades.|
| Objetivo do Teste   | Verificar se o usuário consegue acessar as comunidades. |
| Passos  | 1- Acessar o menu "explorar"<br><br>2- Pesquisar comunidade ou vizualizar comunidades sugeridas<br><br>3- Selecionar comunidade<br><br>4- Acessar comunidade|
|Critério de Êxito | Exibir página da comunidade selecionada.|
|   |   |
| **Caso de Teste** 	| **CT-05– Formar equipes**	|
|	Requisito Associado 	| RF-004 A plataforma deve possuir um sistema de formação de equipes e gerenciamento de membros|
| Objetivo do Teste 	| Verificar se o usuário consegue formar equipes. |
| Passos 	|<br>1-Acessar o menu de equipes<br><br> 2- Clicar no botão "Criar uma nova equipe" localizado no lado superior direito<br><br>3-Adicionar o nome da equipe, ícone, jogo relacionado e descrição><br><br>4-Adicionar usuários desejados a equipe.
|Critério de Êxito |  Equipes formadas. |
|   |   |
| **Caso de Teste**   | **CT-06- Gerenciar membros da equipe** |
| Requisito Associado   | RF-004 A plataforma deve possuir um sistema de formação de equipes e gerenciamento de membros|
| Objetivo do Teste   | Verificar se o líder da equipe consegue gerenciar os membros de sua  equipe. |
| Passos  | 1-Acessar o menu de equipes <br><br>2-Ir até a opção "Minhas equipes" do lado esquerdo da aplicação<br><br>3-Clicar na equipe em que deseja gerenciar<br>4-Selecionar a opção desejada (adicionar ou remover membro)<br><br> 5 -Salvar as alterações <br>|
|Critério de Êxito |Líder realizou o gerenciamento de equipes.|
|   |   |
| **Caso de Teste**   | **CT-07– Adicionar Usuario** |
| Requisito Associado   |RF-005	A plataforma deve conter uma ferramenta para adicionar, remover ou bloquear usuários.|
| Objetivo do Teste   | Verificar se o líder da equipe consegue gerenciar os membros de sua  equipe. |
| Passos  | 1- Localizar o botão" solicitar amizade" no perfil em que deseja enviar a solicitação<br><br>2- Clicar na opção "solicitar amizade"<br><br>3- Aguarde até que o usuário a quem a solicitação foi enviada a aceite.<br><br>7- O usuário que recebeu a solicitação a aceita.|
|Critério de Êxito |Líder realizou o gerenciamento de equipes.|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 08– Remover Usuário** |
| Requisito Associado   |RF-005	A plataforma deve conter uma ferramenta para adicionar, remover ou bloquear usuários.|
| Objetivo do Teste   | Remover o usuario da lista de amigos.|
| Passos  | 1-Acessar a aba de amigos.<br><br>2-Selecionar o usuário a ser removido.<br><br>6-Clicar no botão "desfazer amizade"<br><br>7-Confirmar a remoção do usuário.
|Critério de Êxito |O usuário é removido da lista de amigos|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 09– Bloquear Usuário** |
| Requisito Associado |RF-005	A plataforma deve conter uma ferramenta para adicionar, remover ou bloquear usuários.|
| Objetivo do Teste   | Bloquear usuários |
| Passos  |1- Acessar o perfil do usuário que deseja bloquear<br><br> 2-Clicar no botão "bloquear usuário" no perfil desejado <br><br>3-Confirmar o bloqueio do usuário
|Critério de Êxito    |os conteúdos do usuário bloqueado não serão mais exibidos para o usuário que bloqueou. Isso inclui mensagens, postagens, ou qualquer outro tipo de conteúdo gerado pelo usuário bloqueado.|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 10– Pesquisar Usuário** |
| Requisito Associado |RF-006	A plataforma deve conter uma ferramenta de pesquisa de usuários ou comunidades.|
| Objetivo do Teste   | Pequisar usuários .|
| Passos  | 1- Ir ate a aba "explorar"<br><br>2- Localizar a barra de pesquisa no lado superior direito.<br><br>3- Digitar o nome do usuário desejado
|Critério de Êxito    |Resultado da pesquisa retornando os usuários encontrados .|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 11– Pesquisar Comunidade** |
| Requisito Associado |RF-006	A plataforma deve conter uma ferramenta de pesquisa de usuários ou comunidades.|
| Objetivo do Teste   | Pequisar comunidades.|
| Passos  | 1- Ir ate a aba "explorar"<br><br>2- Localizar a barra de pesquisa no lado superior direito.<br><br>3- Digitar o nome da comunidade 
|Critério de Êxito    |Resultado da pesquisa retornando as comunidades encontradas.|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 12– Denúnciar usuários** |
| Requisito Associado |RF-007	A plataforma deve conter uma ferramenta para denunciar usuários, comunidades e postagens..|
| Objetivo do Teste   | Denúnciar usúarios aos administradores|
| Passos  | 1- Selecionar o perfil que deseja denunciar <br><br>2--Clicar no botão com o ícone(!) .<br><br>3- Digitar o motivo da denúncia na caixa de texto <br><br>4-Clicar em "enviar denúncia"
|Critério de Êxito    |Denúncia encaminhada a um dos administradores|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 12– Denúnciar comunidades** |
| Requisito Associado |RF-007	A plataforma deve conter uma ferramenta para denunciar usuários, comunidades e postagens..|
| Objetivo do Teste   | Denúnciar comunidades aos administradores|
| Passos  | 1- Selecionar a comunidade que deseja denunciar <br><br>2-Clicar no botão com o ícone (!).<br><br>3- Digitar o motivo da denúncia na caixa de texto <br><br>4-Clicar em "enviar denúncia" 
|Critério de Êxito    |Denúncia encaminhada a um dos administradores|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 13– Denúnciar postagens** |
| Requisito Associado |RF-007	A plataforma deve conter uma ferramenta para denunciar usuários, comunidades e postagens..|
| Objetivo do Teste   | Denúnciar postagens aos administradores|
| Passos  | 1- Selecionar a comunidade que deseja denunciar <br><br>2-Clicar no botaõ com o ícone (!) .<br><br>3- Digitar o motivo da denúncia na caixa de texto<br><br> 4-Clicar em "enviar denúncia" 
|Critério de Êxito    |Denúncia encaminhada a um dos administradores|
|   |   |
| **Caso de Teste**   | **Caso de Teste CT- 14– Gerenciar perfil** |
| Requisito Associado |RF-008	A plataforma deve permitir gerenciamento de perfil.|
| Objetivo do Teste   | Verificar se o usuário consegue gerenciar seu prórpio perfil|
| Passos  | 1-Clicar foto de perfil própia  <br><br>2-Fazer alterações desejadas(nome, foto, biografia ou banner).<br><br>3-Clicar no botão "salvar alterações"
|Critério de Êxito    |Gerenciamento de perfil realizado com suceeso.|
|   |   |









