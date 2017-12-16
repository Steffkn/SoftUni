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
	<ul>
        <?php
        if(isset($_GET['num1']) && isset($_GET['num2'])){
            $number1 = intval($_GET['num1']);
            $number2 = intval($_GET['num2']);
            for ($i = 1; $i<= $number1; $i++){
        ?>
                <li>List <?= $i ?>
                    <ul>
        <?php
            for ($y = 1; $y<= $number2; $y++){
        ?>
                        <li>
                            Element  <?= $i ?>. <?= $y ?>
                        </li>
        <?php
                }
        ?>

                    </ul>
                </li>
        <?php
            }
        }
        ?>
	</ul>
</body>
</html>