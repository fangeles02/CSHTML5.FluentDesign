
<h1 align="center">
<img src="./CSHTML5_FluentDesign.png" width="256"/><br />
CSHTML5.FluentDesign
</h1>

<h6 align="center">
  Fluent Design controls and styles for CSHTML5
</h6>



### Install

*NuGet Package*

`Install-Package CSHTML5.FluentDesign`

<https://www.nuget.org/packages/CSHTML5.FluentDesign/>


### Preparation
Add reference to App.xaml

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
             <!--  Fluent Design Styles and Controls  -->
            <ResourceDictionary Source="/CSHTML5.FluentDesign;component/FluentDesign.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```


### Overview
<img src="./CSHTML5_Overview.png" width="1000"/>


### Colors
_Currently, only the Windows 10's Default Blue Color is available and uses the Light Theme._

#### Accent Color
|Sample|Color|Brush|
|-----|-----|-----|
|![#a6d8ff](https://placehold.it/30/a6d8ff/000000?text=+)|ImmersiveSystemAccentLight3|ImmersiveSystemAccentLight3Brush|
|![#76b9ed](https://placehold.it/30/76b9ed/000000?text=+)|ImmersiveSystemAccentLight2|ImmersiveSystemAccentLight2Brush|
|![#429ce3](https://placehold.it/30/429ce3/000000?text=+)|ImmersiveSystemAccentLight1|ImmersiveSystemAccentLight1Brush|
|![#0078d7](https://placehold.it/30/0078d7/000000?text=+)|ImmersiveSystemAccent|ImmersiveSystemAccentBrush|
|![#005a9e](https://placehold.it/30/005a9e/000000?text=+)|ImmersiveSystemAccentDark1|ImmersiveSystemAccentDark1Brush|
|![#004275](https://placehold.it/30/004275/000000?text=+)|ImmersiveSystemAccentDark2|ImmersiveSystemAccentDark2Brush|
|![#002642](https://placehold.it/30/002642/000000?text=+)|ImmersiveSystemAccentDark3|ImmersiveSystemAccentDark3Brush|

**Usage:**
```xml
 <Border Background="{StaticResource ImmersiveSystemAccentBrush}"/>
```


#### Base Color


|Light|Dark|Color|Brush|
|-----|-----|-----|-----|
|![#000000](https://placehold.it/30/000000/000000?text=+)|![#ffffff](https://placehold.it/30/ffffff/000000?text=+)|SystemBaseHighColor|SystemBaseHighColorBrush|
|![#333333](https://placehold.it/30/333333/000000?text=+)|![#cccccc](https://placehold.it/30/cccccc/000000?text=+)|SystemBaseMediumHighColor|SystemBaseMediumHighColorBrush|
|![#666666](https://placehold.it/30/666666/000000?text=+)|![#999999](https://placehold.it/30/999999/000000?text=+)|SytemBaseMediumColor|SytemBaseMediumColorBrush|
|![#999999](https://placehold.it/30/999999/000000?text=+)|![#666666](https://placehold.it/30/666666/000000?text=+)|SystemBaseMediumLowColor|SystemBaseMediumLowColorBrush|
|![#cccccc](https://placehold.it/30/cccccc/000000?text=+)|![#333333](https://placehold.it/30/333333/000000?text=+)|SystemBaseLowColor|SystemBaseLowColorBrush|


#### Alt Color


|Light|Dark|Color|Brush|
|-----|-----|-----|-----|
|![#ffffff](https://placehold.it/30/ffffff/000000?text=+)|![#000000](https://placehold.it/30/000000/000000?text=+)|SystemAltHighColor|SystemAltHighColorBrush|
|![#cccccc](https://placehold.it/30/cccccc/000000?text=+)|![#333333](https://placehold.it/30/333333/000000?text=+)|SystemAltMediumHighColor|SystemAltMediumHighColorBrush|
|![#999999](https://placehold.it/30/999999/000000?text=+)|![#666666](https://placehold.it/30/666666/000000?text=+)|SytemAltMediumColor|SytemAltMediumColorBrush|
|![#666666](https://placehold.it/30/666666/000000?text=+)|![#999999](https://placehold.it/30/999999/000000?text=+)|SystemAltMediumLowColor|SystemAltMediumLowColorBrush|
|![#333333](https://placehold.it/30/333333/000000?text=+)|![#cccccc](https://placehold.it/30/cccccc/000000?text=+)|SystemAltLowColor|SystemAltLowColorBrush|

**Usage:**
```xml
<Border Background="{StaticResource SystemBaseHighColorBrush">
  <TextBlock Foreground="{DynamicResource SystemAltHighColorBrush}"/>
</Border/>
```


### Styles

#### 1. Default Button
_No setting of style is required._

```xml
  <Button Content="Normal Button"/>
```
#### 2. Accented Button

```xml
  <Button Content="Accented Button" Style="{StaticResource Button_Accent}"/>
```
#### 3. Card
_Card style for Button_

```xml
  <Button Style="{StaticResource CardStyle}" Width="200" Height="150"/>
```
#### 4. CheckBox

```xml
  <CheckBox Style="{StaticResource CheckBoxStyle}" Content="CheckBox 1" UseSystemFocusVisuals="False"/>
```
#### 5. RadioButton

```xml
  <RadioButton Style="{StaticResource RadioButtonStyle}" Content="RadioButton 1" UseSystemFocusVisuals="False"/>
```
#### 6. DatePicker
_No setting of style is required_
```xml
  <DatePicker Width="200" HorizontalAlignment="Left" Margin="2"/>
```

#### 7. TimePicker
_No setting of style is required_
```xml
  <TimePicker Width="200" HorizontalAlignment="Left" Margin="2"/>
```
#### 8. Tab Control and Tab Items
_No setting of style is required_
```xml
   <TabControl>
          <TabControl.Items>
              <TabItem Header="Tab 1">

              </TabItem>
              <TabItem Header="Tab 2">

              </TabItem>
              <TabItem Header="Tab 3">

              </TabItem>
          </TabControl.Items>
   </TabControl>
```
#### 9. Expander
```xml
 <Expander Style="{StaticResource ExpanderStyle}" Header="Click to expand"/>
```

#### 10. ComboBox
_You need to set the `UseNativeComboBox` to `False`_
```xml
<ComboBox Width="300" HorizontalAlignment="Left" UseNativeComboBox="False">
      <ComboBox.Items>
          <ComboBoxItem Content="Choice 1"/>
          <ComboBoxItem Content="Choice 2"/>
          <ComboBoxItem Content="Choice 3"/>
      </ComboBox.Items>
</ComboBox>
```

#### 11. TextBox and PasswordBox
_No setting of style is required_
```xml
<TextBox Width="200"/>
<PasswordBox Width="200"/>
```



### Controls
coming soon...
