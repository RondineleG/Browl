Diagrama de contexto para compra e venda de criptomoedas:

+-------------------------+        +------------------------+
| Serviço de Coleta de     |        | Serviço de Análise de    |
| Dados de Mercado        |        | Mercado                  |
+------------^------------+        +------------^------------+
             |                                    |
             |                                    |
             |               +--------------------v-----------+
             |               | Referência: Dados coletados     |
             |               |                                |
             |               |                                |
+------------v------------+  +------------v------------+   +------------+
| Serviço de Normalização |  | Serviço de Previsão de   |   | Referência:|
| de Dados                |  | Preços                   |   | Previsões  |
+------------^------------+  +------------^------------+   +-----^------+
             |                             |                      |
             |               +-------------v----------------------+            
             |               | Referência: Dados normalizados        |
             |               |                                      |
             |               v                                      |
+------------v------------+  +------------v------------+   +------------+
| Serviço de Gerenciamento|  | Serviço de Gerenciamento |   | Referência:|
| de Risco                |  | de Ordem                 |   | Ordens     |
+------------^------------+  +------------^------------+   +-----^------+
             |                             |                      |
             |               +-------------v----------------------+            
             |               | Referência: Riscos gerenciados        |
             |               |                                      |
             |               v                                      |
+------------v------------+  +------------v------------+   +------------+
| Serviço de Conexão à    |  | Serviço de Gerenciamento |   | Referência:|
| Corretora de Criptomoedas|  | de Lucro                 |   | Lucros     |
+------------^------------+  +------------^------------+   +-----^------+
             |                             |                      |
             |               +-------------v----------------------+            
             |               | Referência: Conexão estabelecida      |
             |               |                                      |
             |               v                                      |
+------------v------------+  +------------v------------+   +------------+
| Serviço de Compra/Venda |  | Serviço de Carteira      |   | Referência:|
+------------^------------+  +------------^------------+   | Saldo      |
             |                             |               +-----^------+
             |               +-------------v----------------------+            
             |               | Referência: Transações realizadas    |
             |               |                                      |
             |               v                                      |
+------------v------------+  +------------v------------+   +------------+
| Serviço de Autenticação  |  | Serviço de Monitoramento |   | Referência:|
| e Segurança             |  | e Registro              |   | Registro   |
+-------------------------+  +------------------------+   +------------+
