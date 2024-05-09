# RS.Parking
Desenvolvimento de sistema de estacionamento para estudo de API, EFCore, Docker, Angular

## Futuras implementações
- [x] Multiplas camadas
- [ ] Impressão do recibo de pagamento (bematech)
- [ ] Aplicar globalização e localização
- [ ] Criar o projeto de testes
- [ ] Refatorar
- [ ] Segurança
- [ ] Configurar o projeto para o Docker
- [ ] Configurar o projeto para o Raspberry

## Para rodar o projeto em docker

Abrir a pasta "Docker" e executar o comando abaixo

```
docker compose -p rs-parking build
docker compose -p rs-parking up -d
docker compose -p rs-parking down
```
