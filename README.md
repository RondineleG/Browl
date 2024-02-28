
  # Browl

[![N|Sólido](https://avatars.githubusercontent.com/u/47679413?v=4)](https://github.com/RondineleG/Browl)

[![Status da versão](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Este é o repositório do projeto Browl, um sistema completo cujo objetivo é oferecer serviços de compra e venda de criptomoedas, gestão de carteiras e carteiras, gestão de riscos e atuação em mercados de derivativos.

---
##### Project Management Tracking: [Browl](https://github.com/users/RondineleG/projects/7)

##### Trying to follow an agile methodology


1. `src/Presentation/Browl.Client`   

2.  `src/Services/Browl.Service.AuthSecurity`

3.  `src/Services/Browl.Service.MarketDataCollector`

4. flow
    [![](https://mermaid.ink/img/pako:eNrNVkuP2jAQ_iuR9wooZAMhqVRpgfa02yLgVOXiTRywMHZkOy3P_17nsbAJDhRYaesDZF6fP89kJt6CgIUIeGDGYTw3pkOf-tRQSySvuWoIJTQGjBAUSMwKa7pCzHOV8Tw-avuc_SGtAcGISqPZ_Lp7ZrNdoZ0g_hsHqPXCKJaMYzpTxpn6OxOebn8SD_kCydRS8GK8inDG9WZWlzB1VFPdD8aXkOANLOfvguOVNBENT0r3RCFZCywMQ181o7Q-o4ZvDM-n-nCOj6lcCU7HbcTV73emEgWFPANX9fuAkn1boSD5X_psymF45viF-e6qvMf5yUPERRUq075ACmdoqQjXAVXc7iamwxswSvNyVGGVtED8aK9DrfrdTVMLWCS1CjrGYnE5kWWvuwlq4FLVJ7XdP_G74j3M2vg4QA-tPFIAWEhEA3SpmccoQjx19PJ9DZ1pxFmEpdCZ-pDA0jZHkzq6qB83kySOGZc6ftO-flrUJfEpkfOJGl4cy3Xt_K0dhGn2cqEeNStMqtiVx5cu7mSn40tSzc378Oo81eXxvivKzR_H6yf2jZ-IPDggUIghiowQRTAh0ogwId4DtJ1HK2gImc4c78GG9qsdfqmEoJVEXJHXx-RiNaZENo-LsnVhr3Ico7Ip8AZ57W68Uq6gAZZIXapwqK642zTUB3KumtcHnnoszuYDn-6VK0wkm6xpALwIEoEaIIlDKNEQQ9Uty4M2hvQXY0qWPMlF4G3BCnht02xZpmN2nZ7d6TiWbTXAGnhWr9VzXNd0Oq5j2t1H19k3wCZDMJWlbZvKs-ParuPY1v4vkCnj_w?type=png)](https://mermaid.live/edit#pako:eNrNVkuP2jAQ_iuR9wooZAMhqVRpgfa02yLgVOXiTRywMHZkOy3P_17nsbAJDhRYaesDZF6fP89kJt6CgIUIeGDGYTw3pkOf-tRQSySvuWoIJTQGjBAUSMwKa7pCzHOV8Tw-avuc_SGtAcGISqPZ_Lp7ZrNdoZ0g_hsHqPXCKJaMYzpTxpn6OxOebn8SD_kCydRS8GK8inDG9WZWlzB1VFPdD8aXkOANLOfvguOVNBENT0r3RCFZCywMQ181o7Q-o4ZvDM-n-nCOj6lcCU7HbcTV73emEgWFPANX9fuAkn1boSD5X_psymF45viF-e6qvMf5yUPERRUq075ACmdoqQjXAVXc7iamwxswSvNyVGGVtED8aK9DrfrdTVMLWCS1CjrGYnE5kWWvuwlq4FLVJ7XdP_G74j3M2vg4QA-tPFIAWEhEA3SpmccoQjx19PJ9DZ1pxFmEpdCZ-pDA0jZHkzq6qB83kySOGZc6ftO-flrUJfEpkfOJGl4cy3Xt_K0dhGn2cqEeNStMqtiVx5cu7mSn40tSzc378Oo81eXxvivKzR_H6yf2jZ-IPDggUIghiowQRTAh0ogwId4DtJ1HK2gImc4c78GG9qsdfqmEoJVEXJHXx-RiNaZENo-LsnVhr3Ico7Ip8AZ57W68Uq6gAZZIXapwqK642zTUB3KumtcHnnoszuYDn-6VK0wkm6xpALwIEoEaIIlDKNEQQ9Uty4M2hvQXY0qWPMlF4G3BCnht02xZpmN2nZ7d6TiWbTXAGnhWr9VzXNd0Oq5j2t1H19k3wCZDMJWlbZvKs-ParuPY1v4vkCnj_w)



Este projeto tem como objetivo construir um bot para mercados de derivativos de criptomoedas, como referência utilizei os links abaixo e tecnologias de IA como ChatGPT, BARD, Claude e outras para construí-lo. Então, pode haver alguns bugs aqui, mas juro solenemente resolvê-los. Além disso, observe que textos com erros são possíveis. Apenas aceite.

**References:**

- **Tutorial**: [Building RESTful APIs with ASP.NET Core](https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28)

- **EBook**: [Building Modern SaaS](https://www.oreilly.com/library/view/building-modern-saas/9781804610879/)

- **Videos**: [YouTube Playlist](https://www.youtube.com/playlist?list=PLbq2QKd5ieAt0H551D_0E4bGIYRxbq5HL)


## Somente compra

### Funcionalidades

- Conecte-se via API a uma corretora.
  - [Deepcoin](https://www.deepcoin.com/)
- Insira pedidos de compra e venda.
  - Pegar preço atual ex: 10 colocar ordens de compra abaixo do tipo compra 5 a 9 e 5 a 8
  - Alavancagem, Quantidade, Alvo, 10x, 5 BNB por 10 Comprar por 5 BNB vender por 11
  - Definir o range de atuação range de lucro entre 8 e 12 ex: intervalo de ordens, 10 centavos compra e 25 centavos lucro
  - Ordem: 1 BNB, 10x, 20%, 10c, 25l
  - Buscar preço atual do ativo ex: 10
  - Envio e múltiplas ordens compro 1 bnb por 10 e vendo 1 bnb por 10.25 = lucro 15 centavos
    - Compra 8 e já ordem de venda a 8.25
    - Compro a 8.10 e vendo a 8.35
    - Compro a 8.20 e vendo a 8.45
    - Compro a 12 e vendo a 12.25
  - Fazer alteração do range de acordo com o movimento
  - 24h fora da range, cancelo tudo e inicio um range
- Monitorar pedidos abertos e fechados.
  - De 2 em 2 minutos e verifico a range busquei o preço atual e dentro da range 11, fora 14 e e 6
  - Intervalo 4*10 = 40 ordens de compra, comprei a 8 e 8.10 e vendi a 8.25 e 8.35 Ordem 01 e 02
  - Inserir nova compra pra a ordem finalizada insiro nova ordem no mesmo lugar
- Monitorar preço e volume de ativos.
  - 10 entrando de comprar ele suba, se tiver entrando volume de venda ele caia

## Licença

MIT

**Software Livre, claro!**

