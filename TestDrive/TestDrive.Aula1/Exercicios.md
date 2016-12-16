### Empilhando Controles na Página ###

Suponha que você tenha 4 controles `Label` numa página 
**XAML**:

```
<Label Text="Inglês"/>
<Label Text="Português"/>
<Label Text="Espanhol"/>
<Label Text="Italiano"/>
```

Escolha a alternativa contém o código `XAML` necessário
para exibir esses 4 labels "empilhados" verticalmente:

a. código

```
    <Grid>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </Grid>
```

> O controle `Grid` poderia ser usado para exibir os labels
> em múltiplas linhas, porém é necessário criar definições
> de linhas (RowDefinitions).

b. código

```
    <ListView>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </ListView>
```

> O controle `ListView` é um "repetidor" de layout, isto é,
> ele pode criar várias instâncias dos controles que estão
> contidos em seu template, porém ele não serve como um
> simples "container" de controles, como nesse caso.

c. código

```
    <StackLayout>
        <Label Text="Inglês"/>
    </StackLayout>
    <StackLayout>
        <Label Text="Português"/>
    </StackLayout>
    <StackLayout>
        <Label Text="Espanhol"/>
    </StackLayout>
    <StackLayout>
        <Label Text="Italiano"/>
    </StackLayout>
```

> Está incorreto porque deveríamos ter um único 
> `StackLayout` contendo todos os labels, e não um
> `StackLayout` para cada label.

d. código
```
    <StackLayout>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </StackLayout>
```

CORRETO. O `StackLayout` é um container que por padrão
organiza os controles encapsulados, empilhando-os na
página XAML.

e. código

```
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Label Text="Inglês"/>
        <Label Text="Português"/>
        <Label Text="Espanhol"/>
        <Label Text="Italiano"/>
    </Grid>

```

Essa abordagem poderia funcionar, porém para isso seria
necessário que cada `Label` tivesse definido a propriedade
`Grid.Row`, caso contrário os controles-filhos
serão exibidos "amontoados" uns sobre os outros.

### Problemas com Grids ###

Uma colega desenvolvedora de `Xamarin` precisa criar 
um `Grid` contendo 3 `Labels` organizados verticalmente. 
Ela desenvolve o `Grid`, porem está dificuldades para fazê-lo
funcionar corretamente. Ela relata que os `Labels` estão
se sobrepondo, porém diz que criou as definições de linhas
(RowDefinitions) corretamente.

Ela chama você para ajudá-la. Ao ver o código **XAML**, 
você encontra:

```
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Label Text="Brasil"/>
        <Label Text="Argentina"/>
        <Label Text="Uruguai"/>
    </Grid>
```

O que aconteceu?

Qual seria a mudança necessária para fazer esse layout
funcionar direito?

OPINIÃO DA ALURA:
Da maneira que está, Todos os `Labels` estão sendo exibidos
na primeira Linha.
É necessário definir a propriedade `Grid.Row` para cada
um dos `Labels`, assim:

```
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Label Grid.Row="0" Text="Brasil"/>
        <Label Grid.Row="1" Text="Argentina"/>
        <Label Grid.Row="2" Text="Uruguai"/>
    </Grid>
```

### Trabalhando com Grids ###

Considere os dados da eleição dos EUA de 2016:

```
Trump / Pence    62.829.410  46,10%
Clinton / Kaine  65.483.780  48,05%
Johnson / Weld	  4.476.220   3,28%
Stein / Baraka	  1.449.726   1,06%
```

Crie um trecho de código **XAML** para organizar
esses dados em forma de grade. Utilize `Grid` e `Labels`.

OPINIÃO DA ALURA:
Você pode organizar o `Grid` definindo três colunas
e quatro linhas, e associando os `Labels` às linhas
e colunas adequadas:

```
    <Grid VerticalOptions="Start">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Label Grid.Row="0" Grid.Column="0" Text="Trump / Pence"/>
        <Label Grid.Row="0" Grid.Column="1" Text="62.829.410"/>
        <Label Grid.Row="0" Grid.Column="2" Text="46,10%"/>
        
        <Label Grid.Row="1" Grid.Column="0" Text="Clinton / Kaine"/>
        <Label Grid.Row="1" Grid.Column="1" Text="65.483.780"/>
        <Label Grid.Row="1" Grid.Column="2" Text="48,05%"/>
        
        <Label Grid.Row="2" Grid.Column="0" Text="Johnson / Weld"/>
        <Label Grid.Row="2" Grid.Column="1" Text="4.476.220"/>
        <Label Grid.Row="2" Grid.Column="2" Text="3,28%"/>
        
        <Label Grid.Row="3" Grid.Column="0" Text="Stein / Baraka"/>
        <Label Grid.Row="3" Grid.Column="1" Text="1.449.726"/>
        <Label Grid.Row="3" Grid.Column="2" Text="1,06%"/>
    </Grid>
```

### ListView - Definindo Origem dos Dados ###

Considere o seguinte código XAML com a declaração
de um `ListView`:

```
<ListView x:Name="listViewAlunos">
</ListView>
```

Agora veja o código usado para criar uma lista chamada `alunos`:

```
var alunos = new string [] {
    "Amanda Lorenzetti",
    "Mario Hikari",
    "William Bastos"
};

```

Escolha o trecho de código C# necessário
para preencher a ListView `listViewAlunos´
com os elementos do array `alunos´:

a. código
```
listViewVeiculos = new ListView(alunos);
```

> O controle `ListView` não possui um construtor
> que aceite uma lista com a origem de dados dos
> seus itens.

b. código
```
listViewVeiculos.BindingContext = alunos;
```

> Definir somente a propriedade `BindingContext` 
> sozinha no código C# não é suficiente. É necessário]
> também definir o `Binding` da propriedade `ItemsSource`
> do controle.

c. código
```
listViewVeiculos = alunos;
```

> O controle `listViewVeiculos` é um controle da página
> e deve utilizar a lista `alunos`, e não ser substituído
> por ela, como faz o trecho acima.

d. código
```
listViewVeiculos.ItemsSource = alunos;
```
> CORRETO: a propriedade `ItemsSource` do `ListView`
> é usada para definir a origem de dados para os itens
> do `ListView`.

e. código
```
listViewVeiculos.Items = alunos;
```
> O controler `ListView` não possui uma propriedade
> chamada `Items`.


### ListView Binding ###

Você desenvolveu uma página Mainpage.xaml
do Xamarin Forms, para exibir uma listagem de países.

```
MainPage.xaml
=============
    <ListView x:Name="listViewPaises" ItemsSource="{Binding Paises}">
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

Ao rodar a aplicação, a listagem não exibe os países.
Como você resolveria esse problema?

> OPINIÃO DA ALURA:
> 
> Faltou definir o contexto de binding da página no final do construtor da página:
> ```
> this.BindingContext = this;
> ```
> 
> Esse é um erro muito comum!