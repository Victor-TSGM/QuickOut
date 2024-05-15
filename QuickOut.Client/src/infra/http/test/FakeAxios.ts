import axios from "axios";
import { faker } from "@faker-js/faker";

export const FakeAxios = (): jest.Mocked<typeof axios> => {
  const fakeAxios = axios as jest.Mocked<typeof axios>

  fakeAxios.post.mockResolvedValue({
    data: { id: '1234', 
    name: 'body'},
    status: faker.number.int()
  });
  
  return fakeAxios
}

