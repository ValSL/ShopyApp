import { RoutesPaths } from "@/app/routes";
import apiClient from "@/app/shared/api/axios.client";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { useRouter } from "next/navigation";

export function useRegister<T>() {
	const register = (data: T) => {
		return apiClient.post("auth/register", data);
	};

	return useMutation({
		mutationFn: register,
		onSuccess: () => {},
	});
}

export function useLogin<T>() {
	const login = async (data: T) => {
		return await apiClient.post("auth/login", data);
	};

	return useMutation({
		mutationFn: login,
	});
}

export function useCheckUser() {
	const checkUser = async () => {
		const response = await apiClient.get("auth/check");
		return response;
	};

	return useQuery({
		queryKey: ["user"],
		queryFn: checkUser,
		retry: 0,
	});
}
