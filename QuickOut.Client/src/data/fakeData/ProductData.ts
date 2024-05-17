import { ProductViewModel } from "@/domain/models/ProductViewModel";

export const productData : ProductViewModel[] = [
// Açougue
{ id: 1, name: 'Filé Mignon', description: 'Carne de alta qualidade', barcode: 7891234567890, weight: 1.0, establishmentId: 1, categoryId: 1, price: 89.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/File.png' },
{ id: 2, promotionId: 1,name: 'Picanha', description: 'Carne para churrasco', barcode: 7891234567891, weight: 1.2, establishmentId: 1, categoryId: 1, price: 69.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Picanha.png' },
{ id: 3, promotionId: 1,name: 'Coxão Mole', description: 'Carne para cozidos', barcode: 7891234567892, weight: 1.5, establishmentId: 1, categoryId: 1, price: 39.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Coxao.png' },
{ id: 4, promotionId: 1,name: 'Fraldinha', description: 'Carne para churrasco', barcode: 7891234567893, weight: 1.3, establishmentId: 1, categoryId: 1, price: 49.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Fraldinha.png' },
{ id: 5, name: 'Costela', description: 'Carne para churrasco', barcode: 7891234567894, weight: 2.0, establishmentId: 1, categoryId: 1, price: 29.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Costela.png' },
{ id: 6, name: 'Alcatra', description: 'Carne macia', barcode: 7891234567895, weight: 1.1, establishmentId: 1, categoryId: 1, price: 59.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Alcatra.png' },
{ id: 7, name: 'Maminha', description: 'Carne para churrasco', barcode: 7891234567896, weight: 1.4, establishmentId: 1, categoryId: 1, price: 54.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Maminha.png' },

// Padaria
{ id: 8, promotionId: 1,name: 'Pão Francês', description: 'Pão crocante', barcode: 7891234567897, weight: 0.05, establishmentId: 1, categoryId: 2, price: 0.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Pao.png' },
{ id: 9, name: 'Pão de Queijo', description: 'Pão de queijo mineiro', barcode: 7891234567898, weight: 0.1, establishmentId: 1, categoryId: 2, price: 1.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/PaoQueijo.png' },
{ id: 10, promotionId: 1,name: 'Croissant', description: 'Croissant francês', barcode: 7891234567899, weight: 0.08, establishmentId: 1, categoryId: 2, price: 2.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Croissant.png' },
{ id: 11, name: 'Baguete', description: 'Pão estilo francês', barcode: 7891234567900, weight: 0.2, establishmentId: 1, categoryId: 2, price: 3.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Baguete.png' },
{ id: 12, name: 'Pão Integral', description: 'Pão saudável', barcode: 7891234567901, weight: 0.25, establishmentId: 1, categoryId: 2, price: 4.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/PaoIntegral.png' },
{ id: 13, promotionId: 1,name: 'Pão de Forma', description: 'Pão macio', barcode: 7891234567902, weight: 0.5, establishmentId: 1, categoryId: 2, price: 5.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/PaoForma.png' },
{ id: 14, name: 'Bolo de Chocolate', description: 'Bolo delicioso', barcode: 7891234567903, weight: 1.0, establishmentId: 1, categoryId: 2, price: 9.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Bolo.png' },

// Hortifruti
{ id: 15, promotionId: 1,name: 'Maçã', description: 'Maçã vermelha', barcode: 7891234567904, weight: 0.2, establishmentId: 1, categoryId: 3, price: 2.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Maca.png' },
{ id: 16, name: 'Banana', description: 'Banana prata', barcode: 7891234567905, weight: 0.15, establishmentId: 1, categoryId: 3, price: 1.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Banana.png' },
{ id: 17, promotionId: 1,name: 'Laranja', description: 'Laranja pera', barcode: 7891234567906, weight: 0.25, establishmentId: 1, categoryId: 3, price: 2.49, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Laranja.png' },
{ id: 18, name: 'Tomate', description: 'Tomate italiano', barcode: 7891234567907, weight: 0.3, establishmentId: 1, categoryId: 3, price: 3.49, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Tomate.png' },
{ id: 19, promotionId: 1,name: 'Cenoura', description: 'Cenoura fresca', barcode: 7891234567908, weight: 0.2, establishmentId: 1, categoryId: 3, price: 2.79, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Cenoura.png' },
{ id: 20, name: 'Alface', description: 'Alface americana', barcode: 7891234567909, weight: 0.15, establishmentId: 1, categoryId: 3, price: 1.89, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Alface.png' },
{ id: 21, promotionId: 1,name: 'Batata', description: 'Batata inglesa', barcode: 7891234567910, weight: 0.5, establishmentId: 1, categoryId: 3, price: 3.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Batata.png' },

// Laticínios
{ id: 22, name: 'Leite Integral', description: 'Leite de vaca', barcode: 7891234567911, weight: 1.0, establishmentId: 1, categoryId: 4, price: 4.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Leite.png' },
{ id: 23, promotionId: 1,name: 'Queijo Mussarela', description: 'Queijo fatiado', barcode: 7891234567912, weight: 0.5, establishmentId: 1, categoryId: 4, price: 9.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Queijo.png' },
{ id: 24, name: 'Iogurte Natural', description: 'Iogurte sem açúcar', barcode: 7891234567913, weight: 0.2, establishmentId: 1, categoryId: 4, price: 3.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Iogurte.png' },
{ id: 25, promotionId: 1,name: 'Requeijão', description: 'Requeijão cremoso', barcode: 7891234567914, weight: 0.3, establishmentId: 1, categoryId: 4, price: 5.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Requeijao.png' },
{ id: 26, name: 'Manteiga', description: 'Manteiga com sal', barcode: 7891234567915, weight: 0.2, establishmentId: 1, categoryId: 4, price: 6.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Manteiga.png' },
{ id: 27, promotionId: 1,name: 'Creme de Leite', description: 'Creme de leite fresco', barcode: 7891234567916, weight: 0.2, establishmentId: 1, categoryId: 4, price: 4.49, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Creme.png' },
{ id: 28, name: 'Leite Condensado', description: 'Leite condensado doce', barcode: 7891234567917, weight: 0.4, establishmentId: 1, categoryId: 4, price: 4.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/LeiteCondesado.png' },

// Bebidas
{ id: 29, name: 'Água Mineral', description: 'Água mineral sem gás', barcode: 7891234567918, weight: 1.5, establishmentId: 1, categoryId: 5, price: 2.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Agua.png' },
{ id: 30, promotionId: 1,name: 'Refrigerante', description: 'Refrigerante de cola', barcode: 7891234567919, weight: 2.0, establishmentId: 1, categoryId: 5, price: 5.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Refrigerante.png' },
{ id: 31, name: 'Suco de Laranja', description: 'Suco natural', barcode: 7891234567920, weight: 1.0, establishmentId: 1, categoryId: 5, price: 6.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Suco.png' },
{ id: 32, promotionId: 1,name: 'Cerveja', description: 'Cerveja pilsen', barcode: 7891234567921, weight: 0.5, establishmentId: 1, categoryId: 5, price: 3.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Cerveja.png' },
{ id: 33,promotionId: 1, name: 'Vinho Tinto', description: 'Vinho tinto seco', barcode: 7891234567922, weight: 0.75, establishmentId: 1, categoryId: 5, price: 29.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Vinho.png' },
{ id: 34, promotionId: 1,name: 'Whisky', description: 'Whisky escocês', barcode: 7891234567923, weight: 0.7, establishmentId: 1, categoryId: 5, price: 99.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Whisky.png' },
{ id: 35, name: 'Café', description: 'Café moído', barcode: 7891234567924, weight: 0.25, establishmentId: 1, categoryId: 5, price: 7.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Cafe.png' },

// Limpeza
{ id: 36,promotionId: 1, name: 'Detergente', description: 'Detergente líquido', barcode: 7891234567925, weight: 0.5, establishmentId: 1, categoryId: 6, price: 3.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Detergente.png' },
{ id: 37, name: 'Sabão em Pó', description: 'Sabão em pó para roupas', barcode: 7891234567926, weight: 1.0, establishmentId: 1, categoryId: 6, price: 8.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Sabao.png' },
{ id: 38, name: 'Desinfetante', description: 'Desinfetante floral', barcode: 7891234567927, weight: 0.75, establishmentId: 1, categoryId: 6, price: 4.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Desinfetante.png' },
{ id: 39, promotionId: 1,name: 'Água Sanitária', description: 'Água sanitária', barcode: 7891234567928, weight: 2.0, establishmentId: 1, categoryId: 6, price: 3.49, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/AguaSanitaria.png' },
{ id: 40, name: 'Esponja', description: 'Esponja dupla face', barcode: 7891234567929, weight: 0.1, establishmentId: 1, categoryId: 6, price: 2.49, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Esponja.png' },
{ id: 41,promotionId: 1, name: 'Lustra Móveis', description: 'Lustra móveis com brilho', barcode: 7891234567930, weight: 0.5, establishmentId: 1, categoryId: 6, price: 7.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Lustra.png' },
{ id: 42, name: 'Saco de Lixo', description: 'Saco de lixo 50L', barcode: 7891234567931, weight: 0.5, establishmentId: 1, categoryId: 6, price: 5.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Saco.png' },

// Higiene Pessoal
{ id: 43, name: 'Shampoo', description: 'Shampoo para cabelos secos', barcode: 7891234567932, weight: 0.4, establishmentId: 1, categoryId: 7, price: 15.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Shampoo.png' },
{ id: 44,promotionId: 1, name: 'Condicionador', description: 'Condicionador para cabelos secos', barcode: 7891234567933, weight: 0.4, establishmentId: 1, categoryId: 7, price: 15.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Condicionador.png' },
{ id: 45,promotionId: 1, name: 'Sabonete', description: 'Sabonete hidratante', barcode: 7891234567934, weight: 0.1, establishmentId: 1, categoryId: 7, price: 2.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Sabonete.png' },
{ id: 46, name: 'Pasta de Dente', description: 'Pasta de dente com flúor', barcode: 7891234567935, weight: 0.1, establishmentId: 1, categoryId: 7, price: 3.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Pasta.png' },
{ id: 47,promotionId: 1, name: 'Desodorante', description: 'Desodorante antitranspirante', barcode: 7891234567936, weight: 0.2, establishmentId: 1, categoryId: 7, price: 9.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Desodorante.png' },
{ id: 48, name: 'Hidratante', description: 'Hidratante corporal', barcode: 7891234567937, weight: 0.3, establishmentId: 1, categoryId: 7, price: 12.99, availableQuantity: Math.floor(Math.random() * 100), imageUrl: '/images/products/Hidratante.png' },
];