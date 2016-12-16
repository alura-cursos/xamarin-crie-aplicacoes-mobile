### Navegação Entre Páginas ###

Você está desenvolvendo um app de compras com Xamarin
Forms. Em um dado momento, o cliente finaliza as compras
na página `CarrinhoView` e precisa ir para a página
de pagamento. Escolha a alternativa que contém o código
C# correto para realizar essa navegação.

a. código
```
Navigation.NavigateTo(new PagamentoView());
```
b. código
```
Navigation.Navigate(new PagamentoView());
```
c. código
```
PagamentoView.Navigate();
```
d. código (CORRETO)
```
Navigation.PushAsync(new PagamentoView());
```
e. código
```
NavigateTo(new PagamentoView());
```
OPINIÃO DA ALURA:
O método `PushAsync` da classe `Navigation` adiciona
uma página ao topo da pilha de navegação do Xamarin Forms.

### Binding Complexo ###

Considere Uma aplicação com o seguinte código:

```
MainPage.xaml.cs:
=================

public class Pais
{
    public string Nome { get; set; }
    public string Capital { get; set; }
}

public partial class MainPage : ContentPage
{
    public Pais Pais { get; set; }

    public MainPage()
    {
        this.Pais = new Pais 
		{
			Nome = "Estados Unidos",
			Capital = "Washington"
		};

        InitializeComponent();
        this.BindingContext = this;
    }

    private void botaoProximo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AgendamentoView());
    }
}

MainPage.xaml
=============

<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MeuApp.MainPage"
             Title="{Binding Path=Pais.Nome}">
</ContentPage>

```

Modifique somente o código XAML _MainPage.xaml_ para exibir
a capital do país no título da página.

> OPINIÃO DA ALURA: 
> Você pode criar um binding com o nome da propriedade
> `Nome` do objeto `Pais` no `Title` do `ContentPage`:
> 
> ```
> <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
>              xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
>              x:Class="MeuApp.MainPage"
>              Title="{Binding Path=Pais.Nome}">
> </ContentPage>
> ```
