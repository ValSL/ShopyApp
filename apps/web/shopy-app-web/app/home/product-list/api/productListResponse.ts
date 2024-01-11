import { Product } from "@/app/shared/types/product.type";

export type ProductListResponse = {
	products: Product[],
	productsCount: number
}