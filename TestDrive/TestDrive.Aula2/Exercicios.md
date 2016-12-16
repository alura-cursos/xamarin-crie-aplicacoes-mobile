### Exibindo Label ###

Qual alternativa abaixo representa corretamente um XAML 
com um `Label` dividido em 3 partes?

a. código:
```
<Label>
    <Span Text="Telefone:" FontAttributes="Bold"/>
    <Span Text="12413122" ForegroundColor="Red" />
    <Span Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
</Label>
```

> Os controles `Span` devem estar contidos dentro de
> `FormattedText` e `FormattedString`.

b. código:

```
<Label>
    <Label.FormattedText>
        <FormattedString>
            <Label Text="Telefone:" FontAttributes="Bold"/>
            <Label Text="12413122" ForegroundColor="Red" />
            <Label Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
        </FormattedString>
    </Label.FormattedText>
</Label>
```

> Um controle `Label` não pode conter outros controles
> `Label`.

c. código:
```
<Label>
    <Label Text="Telefone:" FontAttributes="Bold"/>
    <Label Text="12413122" ForegroundColor="Red" />
    <Label Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
</Label>
```

> Um controle `Label` não pode conter outros controles
> `Label`.

d. código:
```
<Label>
    <Label.FormattedText>
        <FormattedString>
            <Span Text="Telefone:" FontAttributes="Bold"/>
            <Span Text="12413122" ForegroundColor="Red" />
            <Span Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
        </FormattedString>
    </Label.FormattedText>
</Label>
```

> CORRETO:
> O label pode ser dividido em uma série de controles `Span`, contidos
> na propriedade `FormattedText.FormattedString`.
> 

e. código:
```
<Label>
    <StackLayout Orientation="Horizontal">
        <Span Text="Telefone:" FontAttributes="Bold"/>
        <Span Text="12413122" ForegroundColor="Red" />
        <Span Text="(Horário de funcionamento: Dias úteis e sábados das 8h às 22h)"/>
    </StackLayout>
</Label>
```

> Os controles `Span` devem estar contidos dentro de
> `FormattedText` e `FormattedString`.


### Exibindo Labels Agrupados Horizontalmente ###

Escreva um trecho de código XAML em que três labels
diferentes com as palavras "Red", "Green" e "Blue" sejam exibidos 
horizontalmente, na mesma linha.

OPINIÃO DA ALURA:
Deve-se colocar os 3 Labels dentro de um StackLayout com 
Orientation="Horizontal", da seguinte forma:

```
<StackLayout Orientation="Horizontal">
    <Label Text="Red"/>
    <Label Text="Green"/>
    <Label Text="Blue"/>
</StackLayout>
```

### Respondendo a Toque com ListView ###

Você desenvolveu uma página Mainpage.xaml
do Xamarin Forms, para exibir uma listagem de países:

```
MainPage.xaml
=============
    <ListView x:Name="listViewPaises" 
    ItemsSource="{Binding Paises}">
    </ListView>

MainPage.xaml.cs
================

    public partial class MainPage : ContentPage
    {
        public List<string> Paises { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.Paises = new List<string>()
            {
                "Brasil",
                "Argentina",
                "Colômbia"
            };
        }
    }
```

Você precisa modificar o código XAML para que o `ListView`
responda a um toque do usuário. Que evento você adicionaria
ao `ListView` do XAML?

a. código
```
    <ListView x:Name="listViewPaises" 
    ItemsSource="{Binding Paises}"
    Touched="listViewPaises_Touched">
    </ListView>
```
> Não existe um evento `Touched` no controle `ListView`.
> 

b. código
```
    <ListView x:Name="listViewPaises" 
    ItemsSource="{Binding Paises}"
    Clicked="listViewPaises_Clicked">
    </ListView>
```
> Não existe um evento `Clicked` no controle `ListView`.

c. código
```
    <ListView x:Name="listViewPaises" 
    ItemsSource="{Binding Paises}"
    SelectedItem="listViewPaises_SelectedItem">
    </ListView>
```
> `SelectedItem` é uma propriedade, e não um evento
> do controle `ListView`.

d. código
```
    <ListView x:Name="listViewPaises" 
    ItemsSource="{Binding Paises}"
    ItemTapped="listViewPaises_ItemTapped">
    </ListView>
```
CORRETO: O evento `ItemTapped` corresponde à ação do
usuário de tocar em um item do `ListView`.

e. código
```
    <ListView x:Name="listViewPaises" 
    ItemsSource="{Binding Paises}"
    ItemTapped="{Binding ItemTapped}">
    </ListView>
```
O evento `ItemTapped` é um evento, que deve ser associado
a um nome de método (como "listViewPaises_ItemTapped"),
e não a um _binding_ de uma propriedade

### Exibindo Um Popup para o Usuário ###

Você desenvolveu uma página Mainpage.xaml
do Xamarin Forms, para exibir uma listagem de países:

```
MainPage.xaml
=============
    <ListView x:Name="listViewPaises" 
    ItemsSource="{Binding Paises}">
    </ListView>

MainPage.xaml.cs
================

    public partial class MainPage : ContentPage
    {
        public List<string> Paises { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.Paises = new List<string>()
            {
                "Brasil",
                "Argentina",
                "Colômbia"
            };
        }

        private void listViewPaises_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            //COLOQUE AQUI SEU CÓDIGO
        }
    }
```

Crie o código necessário para exibir um popup com 
uma mensagem para o usuário com o nome do país selecionado.

> OPINIÃO DA ALURA:
> Você pode utilizar o método `DisplayAlert` para
> exibir uma mensagem para o usuário 
> 
> ```
> DisplayAlert("Atenção",
> string.Format("Você selecionou o país '{0}', e.Item),
> "Ok");
> 
> ```
