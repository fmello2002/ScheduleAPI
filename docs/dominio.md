# Domínio da Schedule API

Documentação do domínio de agendamento de uma clínica: jornada, subdomínios, premissas e glossário (linguagem ubíqua).

## Jornada

- **Passo 0:** Atendente cadastra os horários que a clínica oferece
- **Passo 1:** Cliente verifica dias/horários disponíveis
- **Passo 2:** Cliente faz a solicitação de agendamento
- **Passo 3:** Atendente aprova ou reprova a solicitação de agendamento
- **Passo 4:** Cliente é avisado que a solicitação foi aprovada/reprovada
- **Passo 5** (pode ou não acontecer): Cliente cancela a solicitação de agendamento
- **Passo 6:** Atendente pode cancelar o agendamento
- **Passo 7:** Cliente é avisado do cancelamento

## Subdomínios

| Subdomínio | Tipo | Justificativa | Descrição |
|---|---|---|---|
| Disponibilidade | Suporte | Define os horários que a clínica oferece | Horários cadastrados pelo atendente. |
| Solicitação de agendamento | Suporte | Segura um horário até que o atendente decida | Permite reservar um horário até o atendente decidir. |
| Agendamento | **Central** | Tem as regras principais de agendamento; sem ele a empresa não tem a organização da agenda | Criado após a aprovação da solicitação (pode ser cancelado pelo atendente). |
| Comunicação | Genérico | Resolvido da mesma forma em qualquer empresa | Avisar o cliente sobre a aprovação ou reprovação de solicitações e sobre o cancelamento de agendamentos. |
| Autorização | Genérico | Resolvido da mesma forma em qualquer empresa | Define o que cada papel (cliente ou atendente) pode fazer. |
| Autenticação | Genérico | Resolvido da mesma forma em qualquer empresa | Identifica quem é a pessoa que acessa o sistema. |
| Cadastro de pessoas | Suporte | Necessário para cadastrar as pessoas que irão usar o sistema | Registro de clientes e atendentes. |

## Premissas

- O profissional não existe no sistema.
- A confirmação com o profissional acontece fora do sistema.
- Solicitação e agendamento são conceitos separados: o agendamento só nasce após a aprovação.
- Só pode haver 1 cliente por horário.
- Após o cliente fazer a solicitação, o horário deixa de estar disponível para outros clientes.
- Se o cliente cancelar a solicitação, se o atendente reprovar a solicitação ou se o atendente cancelar o agendamento, o horário volta a ficar disponível.
- Após a aprovação da solicitação, o cliente não pode mais cancelar o agendamento; apenas o atendente pode.

## Glossário

- **Cliente:** Pessoa que faz solicitações de agendamento de acordo com os dias e horários disponíveis.
- **Atendente:** Responsável por cadastrar os horários e por aprovar ou reprovar as solicitações dos clientes.
- **Horário:** Período em que a clínica oferece atendimento, cadastrado pelo atendente.
- **Horário disponível:** Horário cadastrado que não tem solicitação pendente nem agendamento ativo.
- **Solicitação de agendamento:** Pedido de um horário feito pelo cliente para ser atendido, podendo ser cancelado por ele enquanto estiver pendente.
- **Solicitação pendente:** Solicitação que ainda não foi aprovada, reprovada nem cancelada.
- **Agendamento:** Horário reservado definitivamente para o cliente após a aprovação da solicitação, podendo ser cancelado pelo atendente.
- **Aprovar solicitação:** Atendente aceita a solicitação do cliente e o agendamento é criado.
- **Reprovar solicitação:** Atendente recusa a solicitação do cliente e o horário volta a ficar disponível.
- **Cancelar solicitação:** Cliente desiste da solicitação enquanto ela está pendente e o horário volta a ficar disponível.
- **Cancelar agendamento:** Atendente cancela o agendamento e o horário volta a ficar disponível.