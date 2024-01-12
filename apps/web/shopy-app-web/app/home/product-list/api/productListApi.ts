import apiClient from "@/app/shared/api/axios.client";
import { Product } from "@/app/shared/types/product.type";
import { useQuery } from "@tanstack/react-query";
import { ProductListResponse } from "./productListResponse";

export function useGetAllProducts(currentPage: number, pageSize: number) {

	const getAllProducts = async () => {
		const result = await apiClient.get<ProductListResponse>(`products/${currentPage}/${pageSize}`);
		return result.data
	};

	return useQuery({ queryKey: ["allProducts", currentPage, pageSize], queryFn: getAllProducts });
}
