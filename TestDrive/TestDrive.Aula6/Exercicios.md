### Papel do ViewModel ###

Qual das afirmações abaixo sobre o _ViewModel_ é verdadeira?

a. A responsabilidade do ViewModel é definir a aparência ou a estrutura
 que o usuário vê na tela.

b. A ViewModel é uma classe não visual, que expõe para a View uma 
lógica de apresentação.
CORRETA.

c. A ViewModel encapsula a lógica de negócios e os dados. 
Nada mais é do que o modelo de domínio de uma aplicação, ou 
seja, as classes de negócio que serão utilizadas em uma determinada 
aplicação.

OPINIÃO DA ALURA:
O ViewModel é uma abstração da View, que expõe propriedades públicas 
e comandos. É uma classe não visual, que expõe para a View uma 
lógica de apresentação.

### Benefícios do MVVM ###

Quais são os benefícios do MVVM?

> OPINIÃO DA ALURA:
> O principal benefício é permitir a verdadeira separação entre a View e
> o Modelo. Isso significa que, se o modelo necessitar de uma mudança, ele
> pode ser alterado facilmente sem a necessidade de alterar também a View,
> e vice-versa.
> 
> Os benecífios da aplicação do padrão MVVM são:
> 
> - Facilidade de manutenção
> - Testabilidade
> - Extensibilidade

### Notificando a View ###

Considere uma aplicação com uma página de entrada de lançamentos
contábeis:

```
MainPage.xaml:
=============

<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:TestDrive"
             x:Class="TestDrive.MainPage">
    <ContentPage.BindingContext>
        <local:MainViewModel></local:MainViewModel>
    </ContentPage.BindingContext>
    <TableView>
        <TableRoot>
            <TableSection Title="Lançamentos contábeis">
                <EntryCell Label="Saldo Inicial" Text="{Binding SaldoInicial}" 
                           HorizontalTextAlignment="End"
                           Keyboard="Numeric"/>
                <EntryCell Label="Débitos" Text="{Binding Debitos}" 
                           HorizontalTextAlignment="End"
                           Keyboard="Numeric" />
                <EntryCell Label="Créditos" Text="{Binding Creditos}" 
                           HorizontalTextAlignment="End"
                           Keyboard="Numeric" />
                <TextCell Text="{Binding Saldo, StringFormat='Saldo: {0:F0}'}"/>
            </TableSection>
        </TableRoot>
    </TableView>
</ContentPage>

MainPage.xaml.cs:
=================

public class MainViewModel
{
    private decimal saldoInicial;
    public decimal SaldoInicial
    {
        get { return saldoInicial; }
        set { saldoInicial = value; }
    }

    private decimal debitos;
    public decimal Debitos
    {
        get { return debitos; }
        set { saldoInicial = value; }
    }

    private decimal creditos;
    public decimal Creditos
    {
        get { return creditos; }
        set { saldoInicial = value; }
    }

    public decimal Saldo
    {
        get { return SaldoInicial + Debitos - Creditos; }
    }
}

```

Ao rodar o programa, você nota que ao digitar os valores, o saldo final
não é atualizado.

Por que isso acontece?

E quais são as alterações necessárias para que o saldo total dos lançamentos
seja atualizado à medida que o usuário modifica os valores de saldo inicial,
créditos e débitos?

> OPINIÃO DA ALURA:
> 
> A view não está sendo atualizada porque o `ViewModel` não está
> fazendo a notificação necessária.
> 
> Primeiro, é necessário que o `ViewModel` implemente a interface
> `INotifyPropertyChanged`, criando o método `OnPropertyChanged`:
> 
> ```
> public class MainViewModel : INotifyPropertyChanged
> {
>     .
>     .
>     .
>     public event PropertyChangedEventHandler PropertyChanged;
> 
>     public void OnPropertyChanged([CallerMemberName]string name = "")
>     {
>         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
>     }
> }
> ```
> 
> Em seguida, deve-se chamar o método `OnPropertyChanged` passando
> o nome da propriedade que deve ser atualizada(`Saldo`) no _acessor set_ 
> de cada uma das propriedades de entrada de dados:
> 
> ```
> public decimal SaldoInicial
> {
>     get { return saldoInicial; }
>     set
>     {
>         saldoInicial = value;                
>         OnPropertyChanged(nameof(Saldo));
>     }
> }
> ```
> 
> Com isso, 
> 
> Ao final, você terá o `ViewModel` assim:
> 
> ```
> public class MainViewModel : INotifyPropertyChanged
> {
>     private decimal saldoInicial;
>     public decimal SaldoInicial
>     {
>         get { return saldoInicial; }
>         set
>         {
>             saldoInicial = value;                
>             OnPropertyChanged(nameof(Saldo));
>         }
>     }
> 
>     private decimal debitos;
>     public decimal Debitos
>     {
>         get { return debitos; }
>         set
>         {
>             debitos = value;                
>             OnPropertyChanged(nameof(Saldo));
>         }
>     }
> 
>     private decimal creditos;
>     public decimal Creditos
>     {
>         get { return creditos; }
>         set
>         {
>             creditos = value;                
>             OnPropertyChanged(nameof(Saldo));
>         }
>     }
> 
>     public decimal Saldo
>     {
>         get { return SaldoInicial + Debitos - Creditos; }
>     }
> 
>     public event PropertyChangedEventHandler PropertyChanged;
> 
>     public void OnPropertyChanged([CallerMemberName]string name = "")
>     {
>         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
>     }
> }
> ```