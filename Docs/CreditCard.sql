create table CreditCard
(
    CLI_USER              varchar(15)                 not null,
    CC_CREDIT_CARD_NUMBER varchar(22)                 not null,
    CC_CREDIT_CARD_CVV    int                         not null,
    CC_CREDIT_CARD_TYPE   enum ('Mastercard', 'Visa') not null,
    constraint CreditCard_CC_CREDIT_CARD_NUMBER_uindex
        unique (CC_CREDIT_CARD_NUMBER),
    constraint FK_CLI_USER
        foreign key (CLI_USER) references User (CLI_USER)
);

alter table CreditCard
    add primary key (CC_CREDIT_CARD_NUMBER);

