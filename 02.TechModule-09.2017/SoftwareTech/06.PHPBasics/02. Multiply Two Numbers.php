<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num1" />
		M: <input type="text" name="num2" />
        <input type="submit" />
    </form>
    <?php
    if(isset($_GET['num1']) && isset($_GET['num2'])){
        $number1 = htmlspecialchars($_GET['num1']);
        $number2 = htmlspecialchars($_GET['num2']);
        echo $number1 * $number2;
    }
    ?>
</body>
</html>