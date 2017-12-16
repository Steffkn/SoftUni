<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    X: <input type="text" name="num1"/>
    Y: <input type="text" name="num2"/>
    Z: <input type="text" name="num3"/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])) {
    $number1 = htmlspecialchars($_GET['num1']);
    $number2 = htmlspecialchars($_GET['num2']);
    $number3 = htmlspecialchars($_GET['num3']);
    $result = true;

    if ($number1 < 0) {
        $result = !$result;
    }

    if ($number2 < 0) {
        $result = !$result;
    }

    if ($number3 < 0) {
        $result = !$result;
    }

    if($number1 == 0 || $number2 == 0 || $number3 == 0){
        echo "Positive";
    }
    else {
        if ($result) {
            echo "Positive";
        } else {
            echo "Negative";
        }
    }
}
?>
</body>
</html>