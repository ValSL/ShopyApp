import { Card, CardSection, Image, Flex, Text, Button } from "@mantine/core";
import classes from './productItem.module.css'
import { Product } from "@/app/shared/types/product.type";

export const ProductCard = ({ product }: { product: Product; }) => {
	return (
		<Card p={0} className={classes.card} >
			<CardSection>
				<Image
					height={150}
					src={product.imageUrl}
					alt="Norway"
				/>
			</CardSection>
			<Flex p={15} direction="column" gap="10px">
				<Text fw="bold" size="20px">
					{product.title}
				</Text>
				<Flex justify="space-between">
					<Text size="14px" c="#A3A3A3">
						Price:
					</Text>
					<Text fw="bold" size="20px">
						${product.price}
					</Text>
				</Flex>
				<Button>Add to Cart</Button>
			</Flex>
		</Card>
	);
};