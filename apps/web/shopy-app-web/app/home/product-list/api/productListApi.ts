import apiClient from "@/app/shared/api/axios.client";
import { Product } from "@/app/shared/types/product.type";
import { useQuery } from "@tanstack/react-query";

export function useGetAllProducts() {
	const getAllProducts = async () => {
		const result = await apiClient.get<Product[]>("products");
		return result.data
	};

	return useQuery({ queryKey: ["allProducts"], queryFn: getAllProducts });
}
