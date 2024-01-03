import { z } from "zod";

export const ProductSchema = z.object({
	productId: z.number().int(),
	title: z.string().max(255),
	price: z.number(),
	imageUrl: z.string().url(),
	ownerId: z.number().int(),
})