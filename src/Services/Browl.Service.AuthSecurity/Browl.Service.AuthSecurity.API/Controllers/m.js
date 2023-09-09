let primeiroNumero = parseFloat(prompt("Digite o primeiro número:"));
let segundoNumero = parseFloat(prompt("Digite o segundo número:"));
let operador = prompt("Digite a operação (+, -, *, /):");
let resultado;

switch (operador) {
  case "+":
    resultado = primeiroNumero + segundoNumero;
    break;
  case "-":
    resultado = primeiroNumero - segundoNumero;
    break;
  case "*":
    resultado = primeiroNumero * segundoNumero;
    break;
  case "/":
    if (segundoNumero !== 0) {
      resultado = primeiroNumero / segundoNumero;
    } else {
      alert("Erro: divisão por zero!");
    }
    break;
  default:
    alert("Erro: operação inválida!");
}

// Exibe o resultado final
if (resultado !== undefined) {
  alert("Resultado: " + resultado);
}
