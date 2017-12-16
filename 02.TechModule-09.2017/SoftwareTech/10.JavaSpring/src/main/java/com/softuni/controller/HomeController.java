package com.softuni.controller;

import com.softuni.entity.Calculator;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController {
	@GetMapping("/")
	public String index(Model model) {
		model.addAttribute("operator", "+");
		model.addAttribute("view", "views/calculatorForm");
		return "base-layout";
	}

	@PostMapping("/")
	public String calculate(@RequestParam String leftOperand,
							@RequestParam String rightOperand,
							@RequestParam String operator,
							Model model) {

		double num1;
		double num2;

		try{
			num1 = Double.parseDouble(leftOperand);
		}
		catch (NumberFormatException ex){
			num1 = 0;
		}
		try{
			num2 = Double.parseDouble(rightOperand);
		}
		catch (NumberFormatException ex){
			num2 = 0;
		}

		Calculator calc = new Calculator(num1, num2, operator);

		double result = calc.calculateResult();

		model.addAttribute("leftOperand", calc.getLeftOperand());
		model.addAttribute("rightOperand", calc.getRightOperand());
		model.addAttribute("operator", calc.getOperator());
		model.addAttribute("result", result);
		model.addAttribute("view", "views/calculatorForm");
		return "base-layout";
	}
}
