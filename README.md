# Oi, Cheguei!

Este é um projeto em grupo desenvolvido no 3º semestre do curso de Análise e Desenvolvimento de Sistemas da Fatec.

O objetivo foi desenvolver um sistema utilizando a linguagem C# e algum banco de dados. Foi utilizado o .NET Framework e o banco SQLite.

Foi desenvolvido um sistema de gerenciamento de presença e saída de alunos de uma escola.
Quando o pai de um aluno chega na escola para buscá-lo, o porteiro seleciona esse aluno no sistema que envia uma notificação no monitor da sala desse aluno.
Na prática funciona apenas no mesmo computador, não sendo enviado a mensagem para outros disposiivos.

**Principais funções do sistema:**
- Cadastro de funcionário de diferentes cargos (Coordenador, Professor e Porteiro)
- Login com autenticação
- As funções do sistema são liberadas de acordo com o cargo do funcionário
- O porteiro tem acesso apenas a função de enviar a notificação para o aluno
- O professor tem acesso ao sistema de chamada
- O coordenador tem acesso a todos os recursos, incluindo o cadastro de alunos, pais e outros usuários
