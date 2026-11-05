VAR gold = 50

=== shop ===
O mercador encara você.
* {gold >= 30} [Comprar a espada (30 Gold)]
- gold = gold - 30
Você comprou a espada. -> END
* [Sair]
Você foi embora ->END
->DONE