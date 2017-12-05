<?php

namespace CalculatorBundle\Entity;

class Calculator
{
    /**
     * @var float
     */
    private $leftOperand;
    /**
     * @var string
     */
    private $operator;
    /**
     * @var float
     */
    private $rightOperand;

    /**
     * Get left operand
     *
     * @return float
     */
    public function getLeftOperand()
    {
        return $this->leftOperand;
    }

    /**
     * Set left operand
     *
     * @param float $leftOperand
     *
     * @return Calculator
     */
    public function setLeftOperand(float $leftOperand)
    {
        $this->leftOperand = $leftOperand;

        return $this;
    }

    /**
     * Get right operand
     *
     * @return float
     */
    public function getRightOperand()
    {
        return $this->rightOperand;
    }

    /**
     * Set right operand
     *
     * @param float $rightOperand
     *
     * @return Calculator
     */
    public function setRightOperand(float $rightOperand)
    {
        $this->rightOperand = $rightOperand;
        return $this;
    }

    /**
     * Get operator
     *
     * @return string
     */
    public function getOperator()
    {
        return $this->operator;
    }

    /**
     * Set operator
     *
     * @param string $operator
     *
     * @return Calculator
     */
    public function setOperator(string $operator)
    {
        $this->operator = $operator;
        return $this;
    }

}