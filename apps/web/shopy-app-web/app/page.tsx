import { redirect } from "next/navigation";
export default function Default() {
	redirect("/home/product-list");
	return (
		<>
			Test content
		</>
	);
}
