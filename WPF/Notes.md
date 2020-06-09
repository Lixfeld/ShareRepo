## Bindings
### Mode
In general, user-editable control properties, such as those of text boxes and check boxes, default to **two-way** bindings, whereas most other properties default to **one-way** bindings

### UpdateSourceTrigger
The default value for most dependency properties is **PropertyChanged**, while the Text property has a default value of **LostFocus**.

### Examples
TextBox TextProperty
- TwoWay
- LostFocus

TextBlock TextProperty
- OneWay
- PropertyChanged

CheckBox IsCheckedProperty
- TwoWay
- PropertyChanged