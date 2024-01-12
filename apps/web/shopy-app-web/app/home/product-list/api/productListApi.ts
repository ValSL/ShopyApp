import apiClient from "@/app/shared/api/axios.client";
import { Product } from "@/app/shared/types/product.type";
import { useQuery } from "@tanstack/react-query";
import { ProductListResponse } from "./productListResponse";

export function useGetAllProducts(currentPage: number, pageSize: number, query?: string, from?: number, to?: number) {
	const getAllProducts = async () => {
		if (!query && !from && !to) {
			return (await apiClient.get<ProductListResponse>(`products/${currentPage}/${pageSize}`)).data;
		} else {
			return (await apiClient.get<ProductListResponse>(`products/${currentPage}/${pageSize}?query=${query}&from=${from}&to=${to}`)).data;
		}
	};

	return useQuery({ queryKey: ["allProducts", currentPage, pageSize, query, from, to], queryFn: getAllProducts });
}
