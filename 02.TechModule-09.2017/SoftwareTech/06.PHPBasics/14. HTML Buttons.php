<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
    if(isset($_GET['num'])){
        $number = intval( htmlspecialchars($_GET['num']));

        for($i = 1; $i <= $number; $i++) {
    ?>
        <button><?=$i?></button>
    <?php
        }
    }
    ?>
</body>
</html>