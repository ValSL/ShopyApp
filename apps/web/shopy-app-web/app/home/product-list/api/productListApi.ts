import apiClient from "@/app/shared/api/axios.client";
import { Product } from "@/app/shared/types/product.type";
import { useQuery } from "@tanstack/react-query";
import { ProductListResponse } from "./productListResponse";

export function useGetAllProducts(currentPage: number, pageSize: number, query?: string) {
	const getAllProducts = async () => {
		if (!query) {
			return (await apiClient.get<ProductListResponse>(`products/${currentPage}/${pageSize}`)).data;
		} else {
			return (await apiClient.get<ProductListResponse>(`products/${currentPage}/${pageSize}/${query}`)).data;
		}
	};

	return useQuery({ queryKey: ["allProducts", currentPage, pageSize, query], queryFn: getAllProducts });
}
