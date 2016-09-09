shared_examples('default stock levels') do |dir, cmd|

  describe('default stock levels') do

    example('match those in the file') do
      Shop.create(dir, cmd) do |shop|
        expect(shop.send('s')).to eq(['24 17 5990       50', '10 04 2761       17', '01 01 6000      105', '01 12 1045        3'])
      end
    end

  end

end
