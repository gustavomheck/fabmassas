<Window x:Class="Unisc.Massas.Client.Views.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:md="http://materialdesigninxaml.net/winfx/xaml/themes"
        xmlns:m="http://metro.mahapps.com/winfx/xaml/controls"
        xmlns:controls="clr-namespace:Unisc.Massas.Core.Controles;assembly=Unisc.Massas.Core"
        xmlns:local="clr-namespace:Unisc.Massas.Client"
        mc:Ignorable="d"
        Background="{StaticResource BackgroundColor}"
        Height="480"
        Width="600"
        WindowState="Normal"
        WindowStartupLocation="CenterScreen">

    <md:DialogHost>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition />
                <RowDefinition Height="Auto" />
            </Grid.RowDefinitions>

            <Grid Background="{StaticResource BlackBackgroundBrush}"
                  HorizontalAlignment="Stretch"
                  Width="250">
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto" />
                    <RowDefinition Height="Auto" />
                    <RowDefinition />
                </Grid.RowDefinitions>

                <TextBlock Text="Faturador"
                           Style="{StaticResource TextBlockAppTitle}" />
                <Border Grid.Row="1"
                        BorderBrush="#383838"
                        BorderThickness="0,1,0,0" />
                <controls:SideMenu x:Name="sidemnu"
                                   Grid.Row="2"
                                   Background="{StaticResource BlackBackgroundBrush}"
                                   BorderThickness="0"
                                   Margin="0,6,6,0">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="SelectedItemChanged">
                            <i:InvokeCommandAction Command="{Binding SelecionarItemCommand}"
                                                   CommandParameter="{Binding ElementName=sidemnu, Path=SelectedItem}" />
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                    <controls:SideMenuItem Header="Início"
                                           Icon="{StaticResource FaHome}" />
                    <controls:SideMenuItem Header="Cadastros"
                                           Icon="{StaticResource FaWpforms}">
                        <controls:SideMenuItem Header="Encomenda"
                                               TabIndex="0"
                                               Icon="{StaticResource FaIndustry}" />
                        <controls:SideMenuItem Header="Empresa"
                                               TabIndex="1"
                                               Icon="{StaticResource FaIndustry}" />
                        <controls:SideMenuItem Header="Cliente"
                                               TabIndex="2"
                                               Icon="{StaticResource FaUsers}" />
                        <controls:SideMenuItem Header="Produto"
                                               TabIndex="3"
                                               Icon="{StaticResource FaPrint}" />
                        <controls:SideMenuItem Header="Tipo de Massa"
                                               TabIndex="4"
                                               Icon="{StaticResource FaPrint}" />
                    </controls:SideMenuItem>
                    <controls:SideMenuItem Header="Consultas"
                                           Icon="{StaticResource FaCog}">
                        <controls:SideMenuItem Header="Encomendas"
                                               Icon="{StaticResource FaPrint}" />
                        <controls:SideMenuItem Header="Clientes"
                                               Icon="{StaticResource FaPrint}" />
                        <controls:SideMenuItem Header="Estoque"
                                               Icon="{StaticResource FaPrint}" />
                        <controls:SideMenuItem Header="Tipos de Massa"
                                               Icon="{StaticResource FaPrint}" />
                    </controls:SideMenuItem>
                    <controls:SideMenuItem Header="Estoque"
                                           Icon="{StaticResource FaCog}">
                        <controls:SideMenuItem Header="Entrada de Estoque"
                                               Icon="{StaticResource FaPrint}" />
                        <controls:SideMenuItem Header="Saída de Estoque"
                                               Icon="{StaticResource FaPrint}" />
                    </controls:SideMenuItem>
                    <controls:SideMenuItem Header="Ajuda"
                                           Icon="{StaticResource FaQuestionCircle}">
                        <controls:SideMenuItem Header="Pasta Programa"
                                               Icon="{StaticResource FaDesktop}" />
                    </controls:SideMenuItem>
                    <controls:SideMenuItem Header="Sair"
                                           Icon="{StaticResource FaSignOut}" />
                </controls:SideMenu>
            </Grid>

            <ContentPresenter x:Name="content"
                              Grid.Column="1"
                              Content="{Binding Content}" />

            <!--<StackPanel Visibility="Collapsed">
            <Button Content="Empresas"
                    Click="EmpresasOnClick"
                    Margin="20"
                    Padding="5" />
            <Button Content="Encomendas"
                    Click="EncomendasOnClick"
                    Margin="20"
                    Padding="5" />
        </StackPanel>-->
        </Grid>
    </md:DialogHost>
</Window>
